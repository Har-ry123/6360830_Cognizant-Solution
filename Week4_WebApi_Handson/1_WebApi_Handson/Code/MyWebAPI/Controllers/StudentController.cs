using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        static List<string> students = new List<string> { "John", "Steve", "Maria" };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= students.Count)
                return NotFound("Student not found");

            return Ok(students[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            students.Add(name);
            return Ok("Student added successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string name)
        {
            if (id < 0 || id >= students.Count)
                return NotFound("Student not found");

            students[id] = name;
            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= students.Count)
                return NotFound("Student not found");

            students.RemoveAt(id);
            return Ok("Student deleted successfully");
        }
    }
}

