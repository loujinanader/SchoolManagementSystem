using System;
using School.Api.Models.Student;
using School.Api.Repository;
using School.Api.Data;

namespace School.Api.Services
{
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

    public class StudentService : IStudentService
    {
        private readonly SchoolContext _db;
        public StudentService(SchoolContext _db)
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
    }
    
}
