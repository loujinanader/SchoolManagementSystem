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
                throw new Exception("Invalid age");

            if (string.IsNullOrWhiteSpace(student.StudentName))
                throw new Exception("Student name is required");

            // Repository call
            return _repository.CreateStudent(student);
        }
        public bool DeleteStudent(int id) { return _repository.DeleteStudent(id); }
        public Student UpdateStudent(int id, Student student) { return _repository.UpdateStudent(id, student); }
        public Student? GetStudentById(int id) { return _repository.GetStudentById(id); }
        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }
    }
}
//    public class StudentService : IStudentService
//    {
//        private readonly IStudentRepository _repository;
//        public StudentService(IStudentRepository repository)
//        {
//            _repository = repository;
//        }
//        //    public Student CreateStudent(Student student)
//        //    {
//        //        if (student.Age < 5 || student.Age > 18)
//        //        {
//        //            throw new Exception("Invalid student age");
//        //        }
//        //    }
//        //    if (string.IsNullOrEmpty(student.StudentName))
//        //    throw new Exception("Student name cannot be empty");
//        //    if (student.CID <= 0)
//        //    {
//        //        throw new Exception("Invalid class ID");
//        //    }
//        //}
//        public Student CreateStudent(Student student)
//        {
//            if (student.Age < 5 || student.Age > 18)
//            {
//                throw new Exception("Invalid student age");
//            }
//            if (string.IsNullOrWhiteSpace(student.StudentName))
//            {
//                throw new Exception("Student name cannot be empty");
//            }
//            if (student.CID <= 0)
//            {
//                throw new Exception("Invalid class ID");
//            }
//            // Later you'll call the repository here
//            return student;
//        }
//    }
//}