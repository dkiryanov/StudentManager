using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IStudentCourseService
    {
        IEnumerable<StudentPerformanceDto> GetStudentPerformance();
    }
}