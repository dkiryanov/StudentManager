using DAL.UoW;

namespace BLL.Factories
{
    public interface ICourseInfoUoWFactory
    {
        ICourseInfoUnitOfWork GetUnitOfWork(string courseName);
    }
}