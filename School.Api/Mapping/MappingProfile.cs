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
            // Entity -> Response DTO (property names match — no extra config needed)
            CreateMap<Student, StudentDto>();

            // Request DTO -> Entity (set server-controlled fields explicitly)
            CreateMap<CreateStudentRequest, Student>();
        }
    }
}
