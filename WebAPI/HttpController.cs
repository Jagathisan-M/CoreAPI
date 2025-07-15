using InfosysTest.CartModels;
using InfosysTest.DBModel;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfosysTest.WebAPI
{
    [Route("{controller}")]
    [ApiController]
    public class HttpController : ControllerBase
    {
        HttpClient client;
        EmployeeCartContext context;
        IAntiforgery antiforgery;
        HttpContext httpContext;
        public HttpController(IHttpClientFactory _client, EmployeeCartContext _context, IAntiforgery _antiforgery)
        {
            //client = _client.CreateClient("HTTP");
            client = new HttpClient();
            context = _context;
            antiforgery = _antiforgery;
            //httpContext = /*_httpContext*/;
        }

        [HttpGet("/api/csrf")]
        public object GetxsrfToken()
        {
          AntiforgeryTokenSet token =  antiforgery.GetAndStoreTokens(httpContext);

            HttpContext.Response.Cookies.Append("XSRF-TOKEN", token.RequestToken, new CookieOptions() { HttpOnly = false });

            return new { token = token.RequestToken };
        }

        //[HttpGet("Get")]
        //public async void Get()  
        //{
        //    //PM > Scaffold - DbContext "Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models


        //    var obj = await client.GetAsync("https://localhost:44364/" + "Input/Carts");

        //    var test = obj.Content.ReadAsStringAsync();

        //    var aa = JsonSerializer.Deserialize<Carts[]>(test.Result);

        //    var obj1= context.ProductDetail.ToListAsync();
        //    int aaa = obj1.Id;


        //    //var cc = bb.UserID;

        //}

        [HttpGet("Get")]
        public void Get()
        {
            //PM > Scaffold - DbContext "Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models

            var obj1 = context.EmployeeDetail;
            int aaa = obj1.First().Empid;

            ////insert
            //EmployeeDetail obj = new EmployeeDetail()
            //{
            //    EmpName = "Ragu"
            //};
            //context.EmployeeDetail.Add(obj);

            ////update
            //EmployeeDetail obj = context.EmployeeDetail.Where(x => x.EmpName == "Ragu").First();
            //obj.EmpName = "Nath";

            ////delete
            //EmployeeDetail obj = context.EmployeeDetail.Where(x => x.EmpName == "Nath").First();
            //context.EmployeeDetail.Remove(obj);

            context.SaveChanges();

            //var cc = bb.UserID;

        }

        //[ValidateAntiForgeryToken]
        [HttpGet("GetEmpDetail/{empid}")]
        public object GetEmpDetail(int empid)
        {

            var details = context.EmpproductDetail.Where(x => x.Empid == empid).ToList();

            //var aa = (from empp in context.Empproduct
            //          join emppd in bb on empp.EmpproductId equals emppd.EmpproductId into temp
            //          select new
            //          {
            //              EmpID = empid,
            //              title = empp.Title,
            //              price = empp.Price,
            //              qty = temp != null ? temp.Sum(x => x.Quantity != null ? x.Quantity : 0) : 0,
            //              total = (temp != null ? temp.Sum(x => x.Quantity != null ? x.Quantity : 0) : 0) * empp.Price
            //          }).ToList();

            List< EmpproductDetail> obj = new List<EmpproductDetail>();

            foreach (var item in details)
            {
                if (!obj.Where(x => x.Empid == item.Empid && x.EmpproductId == item.EmpproductId).Any())
                {
                    int qty = 0;
                    foreach (var item1 in details)
                    {
                        if (item.EmpproductId == item1.EmpproductId)
                        {
                            qty += item1.Quantity ?? 0;
                        }
                    }

                    obj.Add(new EmpproductDetail()
                    {
                        Empid = empid,
                        EmpproductId = item.EmpproductId,
                        Quantity = qty
                    });
                }
            }

            return (from epd in obj
             join ep in context.Empproduct on epd.EmpproductId equals ep.EmpproductId
                       select new { 
                            EmpID = empid,
                            ProductID = epd.EmpproductId,
                            Title = ep.Title,
                            Price = ep.Price,
                            Qty = epd.Quantity,
                            Total = epd.Quantity * ep.Price
                       }
             ).ToList();
        }
    }
}
