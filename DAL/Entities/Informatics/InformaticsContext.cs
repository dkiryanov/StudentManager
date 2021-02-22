using System.Data.Entity;

namespace DAL.Entities.Informatics
{
    public class InformaticsContext : DbContext
    {
        public InformaticsContext() : base("InformaticsContext")
        { }

        public DbSet<InformaticsCourseInfo> CourseInfos { get; set; }
    }
}