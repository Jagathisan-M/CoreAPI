using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfosysTest
{

    //[Serializable]
    public class Carts
    {
        public int userId { get; set; }
        [JsonPropertyName("products")]
        public List<Product> products { get; set; }
    }

    [Serializable]
    public class Product
    {
        public int UserId;
        public int productId { get; set; }
        public int quantity { get; set; }
    }

    //public class Product
    //{
    //    public int UserId;
    //    public int productId { get; set; }
    //    public int quantity { get; set; }
    //}

    //public class Carts
    //{
    //    public int id { get; set; }
    //    public int userId { get; set; }
    //    public DateTime date { get; set; }
    //    public List<Product> products { get; set; }
    //    public int __v { get; set; }
    //}
}
