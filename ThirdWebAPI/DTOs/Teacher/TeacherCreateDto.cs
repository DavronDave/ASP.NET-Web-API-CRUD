using WebAPICRUD.Models;

namespace WebAPICRUD.DTOs.Teacher
{
    public class TeacherCreateDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public Subject Subject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
