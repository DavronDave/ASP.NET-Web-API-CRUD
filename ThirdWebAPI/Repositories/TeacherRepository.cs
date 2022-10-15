using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdWebAPI.Data;
using WebAPICRUD.Models;

namespace WebAPICRUD.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDBContext _dBContext;

        public TeacherRepository(SchoolDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task CreateTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            _dBContext.Teachers.Add(teacher);
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeleteTeacherById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            var teacher = _dBContext.Teachers.Find(id);
            _dBContext.Remove(teacher);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _dBContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
                return await _dBContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Teacher>> GetTeacherByName(string name)
        {
            return await _dBContext.Teachers.Where(x => x.FName == name).ToListAsync();
        }

        public async Task UpdateTeacher(int id, Teacher teacher)
        {
            var teacherId = _dBContext.Teachers.Find(id);
            if (id != 0)
            {
                teacherId.FName = teacher.FName;
                teacherId.LName = teacher.LName;
                teacherId.Subject = teacher.Subject;
                teacherId.Email = teacher.Email;
                teacherId.Students = teacher.Students;
                await _dBContext.SaveChangesAsync();
            }
        }
    }
}
