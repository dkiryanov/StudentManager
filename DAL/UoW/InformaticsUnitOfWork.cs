using DAL.Entities;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public class InformaticsUnitOfWork : BaseUnitOfWork<InformaticsContext>, ICourseInfoUnitOfWork
    {
        private readonly InformaticsContext _informaticsContext;
        private ICommonRepository<CourseInfo> _informaticsRepository;

        public InformaticsUnitOfWork(InformaticsContext context) : base(context)
        {
            _informaticsContext = context;
        }

        public ICommonRepository<CourseInfo> CourseInfos => _informaticsRepository ?? (_informaticsRepository = new InformaticsRepository(_informaticsContext));

        public override void SaveChanges()
        {
            _informaticsContext.SaveChanges();
        }
    }
}
