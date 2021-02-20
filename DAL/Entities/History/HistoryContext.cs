using System.Data.Entity;

namespace DAL.Entities.History
{
    public class HistoryContext : DbContext
    {
        public HistoryContext() : base("HistoryContext")
        { }

        public DbSet<HistoryCourseInfo> Courses { get; set; }
    }
}