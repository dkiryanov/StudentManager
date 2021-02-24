using System.Data.Entity;

namespace DAL.Entities
{
    public class HistoryContext : DbContext
    {
        public HistoryContext() : base("HistoryContext")
        { }

        public DbSet<CourseInfo> Courses { get; set; }
    }
}