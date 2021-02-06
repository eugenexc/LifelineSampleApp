
using WebAppLifeline.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace WebAppLifeline.DAL
{

    public class LifelineContext : DbContext
    {
        public LifelineContext(DbContextOptions<LifelineContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
