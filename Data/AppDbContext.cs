using BitsOrchestra_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace BitsOrchestra_Test.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BO_Test;Integrated Security=True");
        }
    }
}
