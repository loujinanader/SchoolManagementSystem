using System;
using School.Api.Models;
using School.Api.Services;

namespace School.Api.Repository

    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync(); //IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(int id);
        public Student CreateStudent(Student student);
        public Student UpdateStudent(int id, Student student);
        public bool DeleteStudent(int id);
    }


