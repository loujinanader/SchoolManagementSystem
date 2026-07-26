using Microsoft.EntityFrameworkCore;
using School.Api.Models.ClassRoom;
using School.Api.Models.Student;

namespace School.Api.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<ClassRoom> ClassRooms { get; set; } = null!;
    }
}
