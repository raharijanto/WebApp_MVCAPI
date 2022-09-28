using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Jobs> Jobs { get; set; }

        public DbSet<Salary> Salary { get; set; }
    }
}
