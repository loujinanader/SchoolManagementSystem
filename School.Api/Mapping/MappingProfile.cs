using AutoMapper;
using School.Api.DTO.Request;
using School.Api.DTO.Response;
using School.Api.Models.Student;

namespace School.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.ClassName,
                    opt => opt.MapFrom(s => s.ClassRoom != null ? s.ClassRoom.ClassName : string.Empty));

            CreateMap<CreateStudentRequest, Student>();
        }
    }
}
