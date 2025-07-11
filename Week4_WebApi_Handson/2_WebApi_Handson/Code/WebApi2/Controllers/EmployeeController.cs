using Microsoft.AspNetCore.Mvc;

namespace SwaggerDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // will change this to 'Emp' later
    public class EmployeeController : ControllerBase
    {
        private static readonly List<string> Employees = new()
        {
            "Alice", "Bob", "Charlie"
        };

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetEmployees()
        {
            return Ok(Employees);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult AddEmployee([FromBody] string name)
        {
            Employees.Add(name);
            return Ok(Employees);
        }

        // Demonstrate ActionName
        [HttpGet("details")]
        [ActionName("Details")]
        public IActionResult GetDetails()
        {
            return Ok("This is the employee details endpoint.");
        }
    }
}

