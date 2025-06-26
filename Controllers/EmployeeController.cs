using EmployeeManagementPortal.Model.Entities;
using EmployeeManagementPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeService.GetAllEmployees());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id) {
            var emp = _employeeService.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Post(Employee obj)
        {
            var emp = _employeeService.AddEmployee(obj);
            if (emp == null)
            {
                return BadRequest();
            }
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult Put(Employee obj, [FromRoute] Guid id)
        {
            var emp = _employeeService.UpdateEmplyee(obj, id);

            if (emp == null)
            {
                return NotFound();
            }
            return Ok(new {message="Employee Updated Successfully!",emp});
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            if(!_employeeService.DeleteEmployee(id))
            {
                return NotFound();
            }
            return Ok(new { message = "Employee Deleted Successfully!" });

        }
    }
}
