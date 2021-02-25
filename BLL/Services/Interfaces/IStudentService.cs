using DAL.Entities.Students;

namespace BLL.Services.Interfaces
{
    public interface IStudentService
    {
        Student GetStudentByName(string studentName);
    }
}