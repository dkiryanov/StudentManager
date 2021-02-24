using System.Data.Entity;

namespace DAL.Entities.Students
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base("StudentsContext")
        {}

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AcademicPerformance>()
                .HasKey(x => new { x.StudentId, x.CourseId });
        }
    }
}