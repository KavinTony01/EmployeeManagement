using EmployeeManagementPortal.Model.Entities;

namespace EmployeeManagementPortal.Services
{
    public interface IEmployeeService
    {
         List<Employee> GetAllEmployees();
         Employee? GetEmployeeById(Guid id);
         Employee? AddEmployee(Employee obj);
         Employee? UpdateEmplyee(Employee obj, Guid id);
        bool DeleteEmployee(Guid id);

    }
}
