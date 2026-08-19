using School.Api.DTO.Student;
using School.Api.Models.Student;
namespace School.Api.Services
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