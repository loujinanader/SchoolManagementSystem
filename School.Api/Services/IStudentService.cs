using System;
using School.Api.Models;
using School.Api.Repository;
using School.Api.Services;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(); //IEnumerable<Student> GetAllStudents();
    public Student? GetStudentById(int id);
    public Student CreateStudent(Student student);
    public Student UpdateStudent(int id, Student student);
    public void DeleteStudent(int id);
}
