using School.Api.DTO.Request;
using School.Api.Models.Student;
namespace School.Api.Services.StudentServices
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(int id);
        public Student? CreateStudent(Student student);
        public Student? UpdateStudent(int id, UpdateStudentDto dto);
        public bool DeleteStudent(int id);
    }
}