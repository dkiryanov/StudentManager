using DAL.Entities.Students;

namespace BLL.Services.Interfaces
{
    public interface ICourseService
    {
        Course GetCourseByName(string courseName);
    }
}