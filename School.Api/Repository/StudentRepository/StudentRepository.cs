using Microsoft.EntityFrameworkCore;
using School.Api.Data;
using School.Api.DTO.Request;
using School.Api.Models.Student;

namespace School.Api.Repository.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _db;

        public StudentRepository(SchoolDbContext db) => _db = db;

        public async Task<IEnumerable<Student>> GetAllStudentsAsync() =>
            await _db.Students.Include(s => s.ClassRoom).ToListAsync();

        public async Task<Student?> GetStudentByIdAsync(int id) =>
            await _db.Students.Include(s => s.ClassRoom).FirstOrDefaultAsync(s => s.StudentID == id);

        public async Task<Student> CreateStudentAsync(Student student)
        {
            if (!await _db.ClassRooms.AnyAsync(c => c.ClassId == student.CID))
                throw new ArgumentException("The specified class does not exist.");

            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.StudentID == id);
            if (student == null)
                return false;

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Student?> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.StudentID == id);
            if (student == null)
                return null;

            if (!string.IsNullOrWhiteSpace(dto.StudentName))
                student.StudentName = dto.StudentName;

            if (dto.Age.HasValue)
                student.Age = dto.Age.Value;

            if (dto.CID.HasValue)
            {
                if (!await _db.ClassRooms.AnyAsync(c => c.ClassId == dto.CID.Value))
                    throw new ArgumentException("The specified class does not exist.");
                student.CID = dto.CID.Value;
            }

            await _db.SaveChangesAsync();
            return student;
        }
    }
}