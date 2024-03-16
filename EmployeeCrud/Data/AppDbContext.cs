using EmployeeCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        
        }

        public DbSet<EmployeeModel> employees { get; set; }
    }
}
