using Microsoft.AspNetCore.Mvc;
using SwimmingStyleAPI.DataStore;
using SwimmingStyleAPI.Models.Employee;

namespace SwimmingStyleAPI.Controllers.Employee
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployee()
        {
            var employeeToReturn = EmployeeDataStore.Current.Employees;
            return Ok(employeeToReturn);
        }

        [HttpGet("{EmployeeId}")]
        public ActionResult<EmployeeDto> GetEmployeeById(int EmployeeId)
        {
            var employeeToReturn = EmployeeDataStore.Current.Employees
                  .FirstOrDefault(x => x.Id == EmployeeId);
            if (employeeToReturn == null)
            {
                return NotFound();
            }
            return Ok(employeeToReturn);
        }

        [HttpPost]
        public ActionResult<EmployeeDto> CreateEmployee(int EmployeeId, EmployeeForCreation employee)
        {

            // need to calculate the id of the new employe
            var maxEmployeeId = EmployeeDataStore.Current.Employees.Max(p => p.Id);
            // need to mapping because we work with employee dto and i need to create employee dto
            var finalEmployee = new EmployeeDto()
            {
                Id = ++maxEmployeeId,
                Name = employee.Name,
                Email = employee.Email,
                Role = employee.Role
            };

            EmployeeDataStore.Current.Employees.Add(finalEmployee);

            return CreatedAtAction(
                                    nameof(GetEmployeeById),
                                    new { EmployeeId = finalEmployee.Id },
                                    finalEmployee);
        }

    }
}
