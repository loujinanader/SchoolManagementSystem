using Microsoft.EntityFrameworkCore;
using School.Api.Data;
using School.Api.DTO.Request;
using School.Api.Models.Student;
namespace School.Api.Repository.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _db;
        public StudentRepository(SchoolDbContext db) =>_db = db;
        public IEnumerable<Student> GetAllStudents() => _db.Students.Include(s => s.ClassRoom).ToList();
        public Student? GetStudentById(int id) => _db.Students.Include(s => s.ClassRoom).FirstOrDefault(s => s.StudentID == id);
        public Student CreateStudent(Student student)
        {
            if (!_db.ClassRooms.Any(c => c.ClassId == student.CID))
                throw new ArgumentException("The specified class does not exist.");
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }
        public bool DeleteStudent(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
                return false;
            _db.Students.Remove(student);
            _db.SaveChanges();
            return true;
        }
        public Student? UpdateStudent(int id, UpdateStudentDto dto)
        {
            var studentData = _db.Students.FirstOrDefault(s => s.StudentID == id);
            if (studentData == null)
                return null;
            if (!string.IsNullOrWhiteSpace(dto.StudentName))
                studentData.StudentName = dto.StudentName;
            if (dto.Age.HasValue)
                studentData.Age = dto.Age.Value;
            if (dto.CID.HasValue)
                studentData.CID = dto.CID.Value;
            _db.SaveChanges();
            return studentData;
        }
    }
}