using System.Collections;
using System.Collections.Generic;
using ThirdWebAPI.Models;

namespace WebAPICRUD.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Subject Subject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Student> Students { get; set; }

        public Teacher()
        {
            this.Students = new HashSet<Student>();
        }


    }
    public enum Subject
    {
        English,
        French,
        German,
        Russian,
        History,
        Math
    }
}
