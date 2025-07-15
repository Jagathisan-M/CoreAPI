using System;
using System.Collections.Generic;

namespace InfosysTest.CartModels
{
    public partial class EmployeeDetail
    {
        public EmployeeDetail()
        {
            EmpproductDetail = new HashSet<EmpproductDetail>();
            Empsalary = new HashSet<Empsalary>();
        }

        public int Empid { get; set; }
        public string EmpName { get; set; }

        public virtual ICollection<EmpproductDetail> EmpproductDetail { get; set; }
        public virtual ICollection<Empsalary> Empsalary { get; set; }
    }
}
