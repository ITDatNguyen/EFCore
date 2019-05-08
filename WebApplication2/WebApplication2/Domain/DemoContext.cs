using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Domain
{
    public class DemoContext: DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=ADMIN\SQLEXPRESSADMIN;Database=DemoMvc6;Integrated Security=False;User ID=sa;Password=123456;");//line 3
        //}
    }
}
