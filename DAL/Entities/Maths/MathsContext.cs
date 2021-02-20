using System.Data.Entity;

namespace DAL.Entities.Maths
{
    public class MathsContext : DbContext
    {
        public MathsContext() : base("MathsContext")
        { }

        public DbSet<MathsCourseInfo> CourseInfos { get; set; }
    }
}