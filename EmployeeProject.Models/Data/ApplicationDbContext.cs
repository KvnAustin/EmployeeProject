using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
