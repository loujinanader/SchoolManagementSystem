using School.Api.DTO.Request;
using School.Api.Models.Student;

namespace School.Api.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();
        public Task<Student?> GetStudentByIdAsync(int id);
        public Task<Student> CreateStudentAsync(Student student);
        public Task<Student?> UpdateStudentAsync(int id, UpdateStudentDto dto);
        public Task RemoveStudentAsync(Student student);
        public Task <bool> ClassRoomExistAsync(int ClassId);
        public Task SaveChangesAsync();
    }
}
