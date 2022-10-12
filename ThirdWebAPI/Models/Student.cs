using System.Collections;
using System.Collections.Generic;

namespace ThirdWebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
        //public ICollection<Teacher> Teachers { get; set; }

    }
}
