using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services
{
    public interface IFileService
    {
        IDictionary<string, IEnumerable<CourseInfoDto>> GetCourseInfoDtos();
    }
}