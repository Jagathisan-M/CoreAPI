using InfosysTest.DBModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfosysTest.WebAPI
{

    [ApiController]
    [Route("{controller}")]
    public class CartsController : ControllerBase
    {
        SampleDBContext context;
        public CartsController(SampleDBContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return null;
        }

        [HttpGet("GetCartInfo/{UserId}")]
        public List<CartResponse> GetCartInfo(int UserID)
        {
            Carts[] listCarts = null;
            ProductsDetail[] listProducts = null;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://fakestoreapi.com/carts");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Request.Scheme}://{Request.Host.Value}/" + "Input/Carts");
            WebResponse catsResponse = request.GetResponse();
            Stream responseStream = catsResponse.GetResponseStream();
            if (responseStream != null)
            {
                String CartResponse = new StreamReader(responseStream).ReadToEnd();

                listCarts = JsonSerializer.Deserialize<Carts[]>(CartResponse);
            }

            //WebRequest request1 = WebRequest.Create("https://fakestoreapi.com/products");
            WebRequest request1 = WebRequest.Create($"{Request.Scheme}://{Request.Host.Value}/" + "Input/Products");
            Stream stream = request1.GetResponse().GetResponseStream();
            string CartResonse = new StreamReader(stream).ReadToEnd();
            listProducts = JsonSerializer.Deserialize<ProductsDetail[]>(CartResonse);

            /* //My way

            List<Product> lstprod = new List<Product>();

            foreach (var item in listCarts)
            {
                foreach (var product in item.products)
                {
                    product.UserId = item.userId;
                    lstprod.Add(product);
                }
            }


            List<CartResponse> CartItems = new List<CartResponse>();

            foreach (var item in listCarts.Select(x=>x.userId).Distinct().ToList())
            {
                foreach (var product in lstprod.Where(x=>x.UserId == item))
                {
                    if (CartItems.Where(x => x.userid == item && x.productid == product.productId).Count() == 0)
                    {
                        var productsDetail = listProducts.Where(x => x.id == product.productId).ToList();

                        CartResponse response = new CartResponse();
                        response.userid = item;
                        response.productid = product.productId;
                        response.title = productsDetail.First().title;
                        response.qty = lstprod.Where(x => item == x.UserId && x.productId == product.productId).Sum(x => x.quantity);
                        response.price = productsDetail.First().price;
                        response.todal = lstprod.Where(x => item == x.UserId && x.productId == product.productId).Sum(x => x.quantity) * productsDetail.First().price;

                        CartItems.Add(response);
                    }
                }
            }

            return CartItems.Where(x=>x.userid == UserID).ToList();

            */

            Comparer c = new Comparer();

            var response = (from lc in listCarts.Where(x => x.userId == UserID).SelectMany(x => x.products).ToList()
                            join lp in listProducts on lc.productId equals lp.id
                            select new CartResponse()
                            {
                                userid = UserID,
                                productid = lc.productId,
                                title = lp.title,
                                qty = listCarts.Where(x => x.userId == UserID).SelectMany(x => x.products).Where(x => x.productId == lp.id).Sum(x => x.quantity),
                                price = lp.price,
                                total = listCarts.Where(x => x.userId == UserID).SelectMany(x => x.products).Where(x => x.productId == lp.id).Sum(x => x.quantity) * lp.price
                            }).Distinct(c).ToList();


            return response;
        }
    }

    public class Comparer : IEqualityComparer<CartResponse>
    {
        public bool Equals([AllowNull] CartResponse x, [AllowNull] CartResponse y)
        {
            return x.userid == y.userid && x.productid == y.productid;
        }

        public int GetHashCode([DisallowNull] CartResponse obj)
        {
            return obj != null ? 1 : 0;
        }
    }
}
