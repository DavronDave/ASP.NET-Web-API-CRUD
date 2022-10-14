namespace WebAPICRUD.DTOs.Student
{
    public class StudentCreateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
    }
}
