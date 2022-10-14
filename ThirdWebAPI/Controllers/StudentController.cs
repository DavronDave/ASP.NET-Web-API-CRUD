using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdWebAPI.Models;
using ThirdWebAPI.Repositories;
using WebAPICRUD.DTOs.Student;

namespace ThirdWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository repository,IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StudentReadDto>))]
        public IActionResult GetAllStudets()
        {
            var students = _repository.GetStudents().GetAwaiter().GetResult();
            var mapStudents = _mapper.Map<IEnumerable<StudentReadDto>>(students);
            return Ok(mapStudents);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(202, Type = typeof(StudentReadDto))]
        public async Task<IActionResult> GetStudet(int id)
        {
            var student = await _repository.GetStudent(id);
            if (student == null)
                return NotFound();
            var studentRead = _mapper.Map<StudentReadDto>(student);
            return Ok(studentRead);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(StudentCreateDto))]
        public async Task<IActionResult> CreateStudent(StudentCreateDto student)
        {
            var mapped = _mapper.Map<Student>(student);
            await _repository.CreateStudent(mapped);
            return CreatedAtAction("GetStudet", new {id=student.Id},student);
            // return GetStudet(student.Id);  => this is equal above return type
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentFromRepo = await _repository.GetStudent(id);
            if (studentFromRepo == null)
                return NotFound();
            await _repository.DeleteStudent(id);
            return Ok("Deleted");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateDto student)
        {
            var studentFromRepo = await _repository.GetStudent(id);
            if (studentFromRepo == null)
                return NotFound();

            var mapper = _mapper.Map(student, studentFromRepo);
            await _repository.UpdateSTudent(id, mapper);
            return Ok(mapper);
        }
    }
}
