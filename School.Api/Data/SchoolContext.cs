using Microsoft.EntityFrameworkCore;
using School.Api.Models.ClassRoom;
using School.Api.Models.Student;

namespace School.Api.Data
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) {}
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
//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    base.OnConfiguring(optionsBuilder);
//}

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{   
//    base.OnModelCreating(modelBuilder);
//    modelBuilder.Entity<ClassRoom>()
//        .HasMany<Student>(c => c.Students)
//        .WithOne(s => s.ClassRoom)
//        .HasForeignKey(s => s.CID);
//    modelBuilder.Entity<Student>()
//        .HasOne<ClassRoom>(s => s.ClassRoom)
//        .WithMany(c => c.Students)
//        .HasForeignKey(s => s.CID);
//    modelBuilder.Entity<Student>().HasKey(s => s.StudentID);
//    modelBuilder.Entity<ClassRoom>().HasKey(c => c.ClassId);
//}