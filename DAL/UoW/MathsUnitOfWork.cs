using DAL.Entities;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public class MathsUnitOfWork : BaseUnitOfWork<MathsContext>, ICourseInfoUnitOfWork
    {
        private readonly MathsContext _mathsContext;
        private ICommonRepository<CourseInfo> _mathsRepository;

        public MathsUnitOfWork(MathsContext context) : base(context)
        {
            _mathsContext = context;
        }

        public ICommonRepository<CourseInfo> CourseInfos => _mathsRepository ?? (_mathsRepository = new MathsRepository(_mathsContext));

        public override void SaveChanges()
        {
            _mathsContext.SaveChanges();
        }
    }
}
