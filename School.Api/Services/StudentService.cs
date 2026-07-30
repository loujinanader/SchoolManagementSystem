using System;
using School.Api.Models.Student;
using School.Api.Repository;
using School.Api.Data;

namespace School.Api.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public Student CreateStudent(Student student)
        {
            // Validation
            if (student.Age < 5 || student.Age > 18)
                throw new ArgumentException("Age must be between 5 and 18", nameof(student.Age));

            if (string.IsNullOrWhiteSpace(student.StudentName))
                throw new ArgumentException("Student name is required", nameof(student.StudentName));

            if (student.CID <= 0)
                throw new ArgumentException("Invalid class ID", nameof(student.CID));
           


            return _repository.CreateStudent(student);

           
        }
        public bool DeleteStudent(int id) { return _repository.DeleteStudent(id); }

        public Student UpdateStudent(int id, Student student) {
            if (student.Age < 5 || student.Age > 18)
                throw new ArgumentException("Age must be between 5 and 18", nameof(student.Age));

            if (string.IsNullOrWhiteSpace(student.StudentName))
                throw new ArgumentException("Student name is required", nameof(student.StudentName));

           


            return _repository.UpdateStudent(id, student); }

        public Student? GetStudentById(int id) {
            
                return _repository.GetStudentById(id); }

        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }
    }
}
