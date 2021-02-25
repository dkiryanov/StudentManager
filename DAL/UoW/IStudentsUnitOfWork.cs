using DAL.Entities.Students;
using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public interface IStudentsUnitOfWork : IBaseUnitOfWork
    {
        ICommonRepository<Student> Students { get; }

        ICommonRepository<Course> Courses { get; }

        ICommonRepository<StudentCourse> StudentCourses { get; }
    }
}