using System;
using School.Api.Models;
using School.Api.Repository;
using School.Api.Models.Student;
using School.Api.Data;


namespace School.Api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _db;
        public StudentRepository(SchoolContext _db)
        {
            this._db = _db;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }
        public Student? GetStudentById(int id)
        {
            return _db.Students.FirstOrDefault(s => s.StudentID == id);
        }
        public Student CreateStudent(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }
        public bool DeleteStudent(int id)
        {
            var student = _db.Students
                .FirstOrDefault(s => s.StudentID == id);

            if (student == null)
            {
                return false;
            }

            _db.Students.Remove(student);
            _db.SaveChanges();

            return true;
        }
        public Student UpdateStudent(int id, Student obj)
        {
            var studentData = _db.Students
                .FirstOrDefault(s => s.StudentID == id);

            if (studentData == null)
            {
                return null;
            }

            studentData.StudentName = obj.StudentName;
            studentData.Age = obj.Age;
            studentData.CID = obj.CID;

            _db.SaveChanges();

            return studentData;
        }

    }
}