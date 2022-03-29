using _05___Company_DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___Company_API.Database
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
