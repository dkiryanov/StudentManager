using System.Collections.Generic;
using System.IO;
using System.Linq;
using BLL.DTO;

namespace BLL.Services
{
    public class ImporterService
    {
        public IEnumerable<CourseInfoDto> GetCourseInfoDtos()
        {
            string[] lines = File.ReadAllLines(@"maths.txt");

            string courseName = lines?.FirstOrDefault()?.Split(' ').LastOrDefault();

            List<CourseInfoDto> dtos = new List<CourseInfoDto>(lines.Length - 1);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(' ');
                dtos.Add(new CourseInfoDto()
                {
                    CourseName = courseName,
                    StudentName = splitted.FirstOrDefault(),
                    StudentScore = splitted.LastOrDefault()
                });
            }

            return dtos;
        }
    }
}
