using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdWebAPI.Models;
using WebAPICRUD.Models;

namespace ThirdWebAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task DeleteStudent(int id);
        Task UpdateSTudent(int id, Student student);
        void CreateStudent(Student student);
    }
}
