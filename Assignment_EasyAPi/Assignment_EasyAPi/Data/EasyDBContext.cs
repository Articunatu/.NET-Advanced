using Assignment_EasyAPi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_EasyAPi.Data
{
    public class EasyDBContext : DbContext
    {
        public EasyDBContext(DbContextOptions<EasyDBContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///Seed Product
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    ID = 1,
                    Name = "Forest",
                    Type1 = Typing.Grass,
                    Type2 = Typing.None,
                    Class = "Physical Attacker"
                });
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    ID = 2,
                    Name = "City",
                    Type1 = Typing.Metal,
                    Type2 = Typing.Lightning,
                    Class = "Special Attacker"
                });
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    ID = 3,
                    Name = "Mountain",
                    Type1 = Typing.Earth,
                    Type2 = Typing.Fire,
                    Class = "Physical Wall"
                });
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    ID = 4,
                    Name = "Palace",
                    Type1 = Typing.Water,
                    Type2 = Typing.None,
                    Class = "Special Attacker"
                });
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    ID = 5,
                    Name = "Heaven",
                    Type1 = Typing.Ray,
                    Type2 = Typing.Lightning,
                    Class = "Speical Wall"
                });
        }
    }
}