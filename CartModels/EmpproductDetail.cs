using System;
using System.Collections.Generic;

namespace InfosysTest.CartModels
{
    public partial class EmpproductDetail
    {
        public int EmpproductDetailId { get; set; }
        public int? Empid { get; set; }
        public int? EmpproductId { get; set; }
        public int? Quantity { get; set; }

        public virtual EmployeeDetail Emp { get; set; }
        public virtual Empproduct Empproduct { get; set; }
    }
}
