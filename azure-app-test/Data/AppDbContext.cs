using Microsoft.EntityFrameworkCore;

namespace azure_app_test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

    }
}
