using AutoMapper;
using EFPROJECT.Entity;

namespace EFPROJECT.Mapper
{
    public class EFMapper : Profile
    {
        public EFMapper() 
        {
            CreateMap<Course , CourseDTO>().ReverseMap();
            CreateMap<Course, CourseAll>().ReverseMap();
            CreateMap<Students ,StudentDTO>().ReverseMap();
            CreateMap<Students, StudentsDTOall>().ReverseMap();
            CreateMap<Students, StudentsDTOalll>().ReverseMap();
        }
    }
}
