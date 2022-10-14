using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdWebAPI.Models;
using WebAPICRUD.DTOs;
using WebAPICRUD.Models;

namespace ThirdWebAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task DeleteStudent(int id);
        Task UpdateSTudent(int id, StudentUpdateDto student);
        Task CreateStudent(Student student);
    }
}
