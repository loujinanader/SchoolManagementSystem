using Microsoft.EntityFrameworkCore;
using School.Api.Models.ClassRoom;
using School.Api.Models.Student;
namespace School.Api.Data
{
    public class SchoolDbContext : DbContext
    {
       public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentID);
            modelBuilder.Entity<ClassRoom>()
                .HasKey(c => c.ClassId);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.ClassRoom)
                .WithMany(c => c.Students)
                .HasForeignKey(c => c.CID)
            .OnDelete(DeleteBehavior.Restrict); // Optional: specify delete behavior
        }

    }
}
