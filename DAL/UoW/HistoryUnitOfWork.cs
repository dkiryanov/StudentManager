using DAL.Entities;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public class HistoryUnitOfWork : BaseUnitOfWork<HistoryContext>, ICourseInfoUnitOfWork
    {
        private readonly HistoryContext _historyContext;
        private ICommonRepository<CourseInfo> _historyRepository;

        public HistoryUnitOfWork(HistoryContext context) : base(context)
        {
            _historyContext = context;
        }

        public ICommonRepository<CourseInfo> CourseInfos => _historyRepository ?? (_historyRepository = new HistoryRepository(_historyContext));

        public override void SaveChanges()
        {
            _historyContext.SaveChanges();
        }
    }
}
