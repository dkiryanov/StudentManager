using System.Data.Entity;

namespace DAL.Entities
{
    public class MathsContext : DbContext
    {
        public MathsContext() : base("MathsContext")
        { }

        public DbSet<CourseInfo> CourseInfos { get; set; }
    }
}