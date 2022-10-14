using AutoMapper;
using WebAPICRUD.DTOs.Teacher;
using WebAPICRUD.Models;

namespace WebAPICRUD.Profiles
{
    public class TeacherProfiles:Profile
    {
        public TeacherProfiles()
        {
            CreateMap<Teacher, TeacherReadDto>();
            CreateMap<TeacherCreateDto, Teacher>();
            CreateMap<TeacherUpdateDto, Teacher>();
        }
    }
}
