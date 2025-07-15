using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfosysTest.DBModel
{

    [Serializable]
    public class Carts
    {
        //public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime CartDate { get; set; }

        [JsonPropertyName("products")]
        public List<Product> products { get; set; }
    }

    [Serializable]
    public class Products
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
