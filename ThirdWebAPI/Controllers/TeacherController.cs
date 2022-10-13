using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebAPICRUD.Models;
using WebAPICRUD.Repositories;

namespace WebAPICRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Teacher>))]
        public IActionResult GetAllTeachers()
        {
            var teachers=_repository.GetAllTeachers().GetAwaiter().GetResult();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        public IActionResult GetStudentById(int id)
        {
            var teacherId = _repository.GetTeacherById(id).GetAwaiter().GetResult();
            if (teacherId == null)
                return NotFound();
            return Ok(teacherId);
        }

        [HttpPost]
        [ProducesResponseType(200,Type =typeof(Teacher))]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            _repository.CreateTeacher(teacher).GetAwaiter().GetResult();
            return Ok(teacher);
        }

        [HttpDelete]
        public IActionResult DeleteTeacherById(int id)
        {
            _repository.DeleteTeacherById(id).GetAwaiter().GetResult();
            return Ok(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, Teacher teacher)
        {
            _repository.UpdateTeacher(id, teacher);
            return Ok("Teacher datas are updated");
        }

    }
}
