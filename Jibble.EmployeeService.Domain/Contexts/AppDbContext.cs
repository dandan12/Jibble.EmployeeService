using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jibble.EmployeeService.Domain.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("EmployeeDbConnectionString"));
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
