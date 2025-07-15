using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfosysTest
{
    [Serializable]
    //public class ProductsDetail
    //{
    //    public int id { get; set; }
    //    public string title { get; set; }
    //    public double price { get; set; }
    //}

    public class ProductsDetail
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        //public Rating rating { get; set; }
    }

    public class CartDetails
    {
        public string name { get; set; }
        public int productid { get; set; }
    }
}
