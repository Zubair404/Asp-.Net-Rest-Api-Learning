using System;
using WebApi.Models.Courses;
using Asp_.Models.Courses;
using AutoMapper;
using WebApi.Controllers;
namespace WebApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>().
            ForMember(dest => dest.ProfessorName, opt => 
            opt.MapFrom(src => src.Professor.FirstName + " " + src.Professor.LastName));

            CreateMap<AddCourseRequest, Course>().AfterMap(AfterMap);
            CreateMap<UpdateCourseRequest, Course>().AfterMap(AfterMap);

        }

        private void AfterMap(UpdateCourseRequest src, Course dest)
        {
                dest.Professor = new Professor
            {
                FirstName = src.ProfessorFirstName,
                LastName = src.ProfessorLastName
            };
        }

        public void AfterMap(AddCourseRequest src, Course dest)
        {
            dest.Professor = new Professor
            {
                FirstName = src.ProfessorFirstName,
                LastName = src.ProfessorLastName
            };
        }
    }
}
