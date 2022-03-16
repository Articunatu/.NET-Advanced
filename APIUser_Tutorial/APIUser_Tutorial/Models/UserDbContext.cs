using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser_Tutorial.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///Seed Data
            modelBuilder.Entity<User>().HasData(new User { ID= 109, Name = "Scar"});
            modelBuilder.Entity<User>().HasData(new User { ID = 110, Name = "Toph" });
            modelBuilder.Entity<User>().HasData(new User { ID = 111, Name = "Blur" });
        }
    }
}
