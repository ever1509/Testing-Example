using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Application.Common.Mappings;
using API2.Domain.Entities;
using AutoMapper;

namespace API2.Application.Courses.Queries.GetCourses
{
    public class CourseDto:IMapFrom<CourseDto>
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseDto>()
                .ForMember(d => d.Title, opt => opt.MapFrom(e => e.Title))
                .ForMember(d => d.Location, opt => opt.MapFrom(e => e.Location))
                .ForMember(d => d.Department, opt => opt.MapFrom(e => e.Department))
                .ForMember(d => d.CourseId, opt => opt.MapFrom(e => e.CourseId))
                .ForMember(d => d.Instructor, opt => opt.MapFrom(e => e.Instructor.Name));
        }
    }
}
