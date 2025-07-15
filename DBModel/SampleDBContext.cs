using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfosysTest.DBModel
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Carts> Carts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsDetail> ProductsDetails { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source=localhost;Initial catalog=EmployeeProject;Integrated Security=SSPI");
        //}
    }
}
