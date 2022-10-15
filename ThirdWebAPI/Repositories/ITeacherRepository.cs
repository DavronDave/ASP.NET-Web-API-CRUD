using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPICRUD.Models;

namespace WebAPICRUD.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task<IEnumerable<Teacher>> GetTeacherByName(string name);
        Task CreateTeacher(Teacher teacher);
        Task UpdateTeacher(int id, Teacher teacher);
        Task DeleteTeacherById(int id);
    }
}
