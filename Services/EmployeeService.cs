using EmployeeManagementPortal.DB;
using EmployeeManagementPortal.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeManagementPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext __DBContext;

        public EmployeeService(ApplicationDBContext dbContext)
        {
            __DBContext = dbContext;
        }


        public List<Employee> GetAllEmployees()
        {
            return __DBContext.Employees.ToList();
        }
        public Employee GetEmployeeById(Guid id)
        {
            var Employee = __DBContext.Employees.Find(id);

            return Employee;
        }
        public Employee UpdateEmplyee(Employee obj, Guid id)
        {
            var Employee = __DBContext.Employees.Find(id);

           
                Employee.Name = obj.Name;
                Employee.Location = obj.Location;
                Employee.DOB = obj.DOB;
                Employee.Mobile = obj.Mobile;
                Employee.IsActive = obj.IsActive;
                __DBContext.SaveChanges();
            
            return Employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            Employee emp = new Employee
            {
                Name = employee.Name,
                DOB = employee.DOB,
                Location = employee.Location,
                Mobile = employee.Mobile,
                IsActive = employee.IsActive,
            };
            __DBContext.Add(employee);
            __DBContext.SaveChanges();
            return emp;
        }
        public bool DeleteEmployee(Guid id)
        {
            var employee = __DBContext.Employees.Find(id);
            
                __DBContext.Employees.Remove(employee);
                __DBContext.SaveChanges();
                return true;


        }
    }
}
