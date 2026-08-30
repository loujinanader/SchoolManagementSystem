using Microsoft.EntityFrameworkCore;
using School.Api.Data;
using School.Api.DTO.Request;
using School.Api.Models.Student;
using System.Globalization;

namespace School.Api.Repository.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _db;
        public StudentRepository(SchoolDbContext db) => _db = db;
        public async Task<IEnumerable<Student>> GetAllStudentsAsync() => await _db.Students.Include(s => s.ClassRoom).ToListAsync();

        public async Task<Student?> GetStudentByIdAsync(int id) => await _db.Students.Include(s => s.ClassRoom).FirstOrDefaultAsync(s => s.StudentID == id);

        public async Task<Student> CreateStudentAsync(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task  RemoveStudentAsync(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

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
        public Task SaveChangesAsync() => _db.SaveChangesAsync();

        public Task<bool> ClassRoomExistAsync(int classId) =>
             _db.ClassRooms.AnyAsync(c => c.ClassId == classId);
        public async Task<IEnumerable<Student>> GetAllStudentsAsync(string? name, int? age, string? sortBy, int page, int pageSize)
        {
            { var query = _db.Students.Include(s => s.ClassRoom).AsQueryable(); 
                if (!string.IsNullOrWhiteSpace(name)) query = query.Where(s => s.StudentName.Contains(name)); 
                if (age.HasValue) query = query.Where(s => s.Age == age.Value); query = sortBy?.ToLower() switch { "name" => query.OrderBy(s => s.StudentName), "age" => query.OrderBy(s => s.Age), _ => query.OrderBy(s => s.StudentID) }; 
                
                query = query.Skip((page - 1) * pageSize).Take(pageSize);
                return await query.ToListAsync(); 
            }
        }



    }
}