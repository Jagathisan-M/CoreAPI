using System;
using System.Collections.Generic;

namespace InfosysTest.CartModels
{
    public partial class Empsalary
    {
        public int EmpsalaryId { get; set; }
        public int? Empid { get; set; }
        public int? Salary { get; set; }

        public virtual EmployeeDetail Emp { get; set; }
    }
}
