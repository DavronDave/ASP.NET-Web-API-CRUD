using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdWebAPI.Data;
using ThirdWebAPI.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPICRUD.Models;
using WebAPICRUD.DTOs.Student;

namespace ThirdWebAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDBContext _schoolDB;

        public StudentRepository(SchoolDBContext schoolDB)
        {
            _schoolDB = schoolDB;
        }
        public async Task CreateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Sorry");

            await _schoolDB.AddAsync(student);
            await _schoolDB.SaveChangesAsync();
        }

        //public void CreateStudent(Student student, Teacher teacher)
        //{
        //    if(student==null && teacher==null)
        //        throw new ArgumentNullException(nameof(student));
        //    _schoolDB.Students.Add(student);
        //    _schoolDB.Teachers.Add(teacher);
        //    _schoolDB.SaveChanges();
        //}

        public async Task DeleteStudent(int id)
        {
            if(id == 0)
                throw new ArgumentNullException(nameof(id));
            var student=_schoolDB.Students.FirstOrDefault(s => s.Id == id); 
            _schoolDB.Students.Remove(student);
            await _schoolDB.SaveChangesAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _schoolDB.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            if (_schoolDB.Students == null)
                throw new ArgumentNullException("No students");
            return await _schoolDB.Students.ToListAsync();
        }

        public Task UpdateSTudent(int id, Student student)
        {
            var studentId = _schoolDB.Students.Find(id);
            if(studentId != null)
            {
                studentId.FirstName = student.FirstName;
                studentId.LastName = student.LastName;
                studentId.Email = student.Email;
                studentId.Course=student.Course;
                _schoolDB.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }
    }
}
