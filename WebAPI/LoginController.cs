using InfosysTest.CartModels;
using InfosysTest.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfosysTest.WebAPI
{
    [Route("{controller}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        EmployeeCartContext context;
        public LoginController(EmployeeCartContext _context)
        {
            context = _context;
        }

        [HttpGet("/GetAllUser")]
        public List<UserLogin> GetAllUser ()
        {
            return context.UserLogin.ToList();
        }

        [HttpGet("CheckValidUser/{userName}/{password}")]
        public bool CheckValidUser(string userName, string password)
        {
            BusinessLayer obj1 = new BusinessLayer();
            obj1.input = 15;

            //BusinessLayer obj2 = new BusinessLayer();
            //obj2.input = 15;

            BusinessLayer obj2 = obj1;

            if (obj1 == obj2) 
                Console.WriteLine(true); 
            else 
                Console.WriteLine(false);

            if(obj1.Equals(obj2))
                Console.WriteLine(true);
            else
                Console.WriteLine(false);


            return context.UserLogin.Where(x => x.UserName == userName && x.Password == password).Count() > 0;
        }

        public async void getdate()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("", "");
            var data = await client.GetAsync("");
            string aa = data.Content.ReadAsStringAsync().Result;

            WebRequest request = WebRequest.Create("");
            string result = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();

            int[] test = new int[6];
            List<int> test1 = new List<int>();
            LinkedList<int> test2 = new System.Collections.Generic.LinkedList<int>();
            Hashtable ht = new Hashtable();
            ht.Add("", "");
            ht.Add(1, 2);
        }
    }
}
