using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfosysTest.DBModel
{
    [Serializable]
    public class ProductsDetail
    {
        public int ID { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
