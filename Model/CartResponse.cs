using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfosysTest
{
    public class CartResponse
    {
		public int userid { get; set; }
		public int productid { get; set; }
		public string title { get; set; }
		public int qty { get; set; }
		public double price { get; set; }
		public double total { get; set; }
	}
}
