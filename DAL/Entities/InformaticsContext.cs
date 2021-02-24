using System.Data.Entity;

namespace DAL.Entities
{
    public class InformaticsContext : DbContext
    {
        public InformaticsContext() : base("InformaticsContext")
        { }

        public DbSet<CourseInfo> CourseInfos { get; set; }
    }
}