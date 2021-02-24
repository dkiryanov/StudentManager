using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public interface ICourseInfoUnitOfWork : IBaseUnitOfWork
    {
        ICommonRepository<CourseInfo> CourseInfos { get; }
    }
}