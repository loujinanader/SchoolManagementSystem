using School.Api.DTO.Request;
using School.Api.Models.Student;
using School.Api.Repository.StudentRepository;
namespace School.Api.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public Student CreateStudent(Student student) => _repository.CreateStudent(student);
        public bool DeleteStudent(int id) => _repository.DeleteStudent(id);
        public Student UpdateStudent(int id, UpdateStudentDto dto) => _repository.UpdateStudent(id, dto);

        public Student? GetStudentById(int id) => _repository.GetStudentById(id);

        public IEnumerable<Student> GetAllStudents() => _repository.GetAllStudents();
    }
}
