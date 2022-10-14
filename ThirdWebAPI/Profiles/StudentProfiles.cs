using AutoMapper;
using ThirdWebAPI.Models;
using WebAPICRUD.DTOs.Student;

namespace WebAPICRUD.Profiles
{
    public class StudentProfiles:Profile
    {
        public StudentProfiles()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<StudentCreateDto, Student>();
        }
    }
}
