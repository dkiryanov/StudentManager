using DAL.Entities;
using DAL.Entities.Students;

namespace DAL.UoW
{
    /// <summary>
    /// Implementation of the unit of work pattern.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentManagerContext _studentsContext;
        private readonly HistoryContext _historyContext;
        private readonly InformaticsContext _informaticsContext;
        private readonly MathsContext _mathsContext;

        private ICourseInfoUnitOfWork _historyUoW;
        private ICourseInfoUnitOfWork _informaticsUoW;
        private ICourseInfoUnitOfWork _mathsUoW;
        private IStudentsUnitOfWork _studentsUoW;

        public UnitOfWork()
        {
            _studentsContext = new StudentManagerContext();
            _historyContext = new HistoryContext();
            _informaticsContext = new InformaticsContext();
            _mathsContext = new MathsContext();
        }

        public ICourseInfoUnitOfWork History => _historyUoW ?? (_historyUoW = new HistoryUnitOfWork(_historyContext));

        public ICourseInfoUnitOfWork Maths => _mathsUoW ?? (_mathsUoW = new MathsUnitOfWork(_mathsContext));

        public ICourseInfoUnitOfWork Informatics => _informaticsUoW ?? (_informaticsUoW = new InformaticsUnitOfWork(_informaticsContext));

        public IStudentsUnitOfWork Students => _studentsUoW ?? (_studentsUoW = new StudentsUnitOfWork(_studentsContext));
    }
}