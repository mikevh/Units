using AutoMapper;
using Units.Data;
using Units.Data.Models;

namespace Units.App_Start
{
    public class MappingConfig
    {
        public static void SetupMaps()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Course, CourseDTO>().ReverseMap();
                c.CreateMap<Student, StudentDTO>().ReverseMap();
                c.CreateMap<Grade, GradeDTO>().ReverseMap();
                c.CreateMap<Todo, TodoDTO>().ReverseMap();
            });
        }
    }
}
