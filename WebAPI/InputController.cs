using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfosysTest.WebAPI
{
    [ApiController]
    [Route("{controller}")]
    public class InputController
    {
        [HttpGet("Carts")]
        public string GetCarts()
        {
            return InputJsonString.Carts;
        }

        [HttpGet("Products")]
        public string GetProducts()
        {
            return InputJsonString.Products;
        }

        [HttpPost("CartDetails")]
        public CartDetails Post([FromBody] CartDetails cartDetails)
        {
            Console.WriteLine(cartDetails);
            return cartDetails;
        }
    }
}
