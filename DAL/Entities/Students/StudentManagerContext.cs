using System.Data.Entity;

namespace DAL.Entities.Students
{
    public class StudentManagerContext : DbContext
    {
        public StudentManagerContext() : base("StudentsContext")
        {}

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}