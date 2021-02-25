using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IFileService
    {
        IDictionary<string, IEnumerable<CourseInfoDto>> GetCourseInfoDtos();
    }
}