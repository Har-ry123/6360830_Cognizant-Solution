using EmployeeApi.Filters;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 60000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    }
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        public ActionResult<List<Employee>> GetStandard()
        {
            throw new Exception("Simulated exception"); // For custom exception filter
            // return Ok(_employees);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee emp)
        {
            return Ok(emp); // In real scenario, you'd save it
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee emp)
        {
            return Ok(emp); // In real scenario, you'd update it
        }
    }
}

