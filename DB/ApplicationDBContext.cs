using EmployeeManagementPortal.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementPortal.DB
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
