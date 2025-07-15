using System;
using System.Collections.Generic;

namespace InfosysTest.CartModels
{
    public partial class Empproduct
    {
        public Empproduct()
        {
            EmpproductDetail = new HashSet<EmpproductDetail>();
        }

        public int EmpproductId { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<EmpproductDetail> EmpproductDetail { get; set; }
    }
}
