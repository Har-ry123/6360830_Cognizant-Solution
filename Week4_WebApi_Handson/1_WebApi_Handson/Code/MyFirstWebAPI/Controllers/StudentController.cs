using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        // Temporary in-memory student list
        static List<string> students = new List<string> { "John", "Steve", "Maria" };

        // GET: api/student
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(students);
        }

        // GET: api/student/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= students.Count)
                return NotFound("Student not found");

            return Ok(students[id]);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult Post([FromBody] string student)
        {
            students.Add(student);
            return Ok("Student added");
        }

        // PUT: api/student/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string student)
        {
            if (id < 0 || id >= students.Count)
                return NotFound("Student not found");

            students[id] = student;
            return Ok("Student updated");
        }

        // DELETE: api/student/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= students.Count)
                return NotFound("Student not found");

            students.RemoveAt(id);
            return Ok("Student deleted");
        }
    }
}

