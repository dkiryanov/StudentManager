using DAL.Entities;

namespace DAL.Repositories.Implementations
{
    internal class HistoryRepository : CommonRepository<CourseInfo>
    {
        public HistoryRepository(HistoryContext context) : base(context)
        {
        }
    }
}