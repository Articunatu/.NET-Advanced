using _04___REST_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _04___REST_API.EntityFramework
{
    public class RestDbContext : DbContext
    {
        public RestDbContext(DbContextOptions<RestDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Weblink> Weblinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
