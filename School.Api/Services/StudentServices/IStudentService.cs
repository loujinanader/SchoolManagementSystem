using School.Api.DTO.Request;
using School.Api.DTO.Response;

namespace School.Api.Services.StudentServices
{
    public interface IStudentService
    {
       public Task<IEnumerable<StudentDto>> GetAllStudentsAsync(string? name, int? age, string? sortBy, int page, int pageSize);
        public Task<StudentDto?> GetStudentByIdAsync(int id);
        public Task<StudentDto> CreateStudentAsync(CreateStudentRequest request);
        public Task<StudentDto?> UpdateStudentAsync(int id, UpdateStudentDto dto);
        public Task<bool> DeleteStudentAsync(int id);
        
    }
}