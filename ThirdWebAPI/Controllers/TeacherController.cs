using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPICRUD.DTOs.Teacher;
using WebAPICRUD.Models;
using WebAPICRUD.Repositories;

namespace WebAPICRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TeacherReadDto>))]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _repository.GetAllTeachers();
            var mapper = _mapper.Map<IEnumerable<TeacherReadDto>>(teachers);
            return Ok(mapper);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TeacherReadDto))]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var teacherId = await _repository.GetTeacherById(id);
            if (teacherId == null)
                return NotFound();
            var mapped = _mapper.Map<TeacherReadDto>(teacherId);
            return Ok(mapped);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TeacherReadDto>))]
        public async Task<IActionResult> GetTeachersByName(string name)
        {
            var teachers =await _repository.GetTeacherByName(name);
            if (teachers == null)
                return NotFound();

            var mappedTeacher = _mapper.Map<IEnumerable<TeacherReadDto>>(teachers);
            return Ok(mappedTeacher);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TeacherCreateDto))]
        public async Task<IActionResult> CreateTeacher(TeacherCreateDto teacher)
        {
            var mapped = _mapper.Map<Teacher>(teacher);
            await _repository.CreateTeacher(mapped);
            return Ok(mapped);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacherById(int id)
        {
            await _repository.DeleteTeacherById(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherUpdateDto teacherDto)
        {
            var teacher = await _repository.GetTeacherById(id);
            if (teacher == null)
                return NotFound(teacher);

            var mapped = _mapper.Map(teacherDto, teacher);
            await _repository.UpdateTeacher(id, mapped);
            return Ok(mapped);
        }

    }
}
