using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdWebAPI.Models;
using ThirdWebAPI.Repositories;

namespace ThirdWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetAllStudets()
        {
            return Ok(_repository.GetStudents().GetAwaiter().GetResult());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        public IActionResult GetStudet(int id)
        {
            var student = _repository.GetStudent(id).GetAwaiter().GetResult();
            if(student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Student))]
        public IActionResult CreateStudent(Student student)
        {
            _repository.CreateStudent(student);
            return Ok(student);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
            return Ok("Deleted");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
           _repository.UpdateSTudent(id, student);
            return Ok(student);
        }
    }
}
