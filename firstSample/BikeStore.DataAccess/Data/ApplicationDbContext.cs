using Microsoft.EntityFrameworkCore;
using BikeStore.DataAccess;
using BikeStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BikeStore.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<BikeType> BikeType { get; set; }

        public DbSet<Tire> Tire { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Add tables here
    }
}
