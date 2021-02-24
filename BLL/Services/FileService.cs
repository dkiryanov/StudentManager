using System.Collections.Generic;
using System.IO;
using System.Linq;
using BLL.DTO;

namespace BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IList<string> _settings;

        public FileService()
        {
            _settings = new List<string>()
            {
                "maths.txt",
                "informatics.txt",
                "history.txt"
            };    
        }

        public IDictionary<string, IEnumerable<CourseInfoDto>> GetCourseInfoDtos()
        {
            Dictionary<string, IEnumerable<CourseInfoDto>> result = new Dictionary<string, IEnumerable<CourseInfoDto>>();

            foreach (string filePath in _settings)
            {
                KeyValuePair<string, IEnumerable<CourseInfoDto>> fileDtos = GetCourseInfoDtos(filePath);

                if (result.ContainsKey(fileDtos.Key))
                {
                    continue;
                }

                result.Add(fileDtos.Key, fileDtos.Value);
            }

            return result;
        }

        private KeyValuePair<string, IEnumerable<CourseInfoDto>> GetCourseInfoDtos(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            string courseName = lines.FirstOrDefault()?.Split(' ').LastOrDefault();

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

            return new KeyValuePair<string, IEnumerable<CourseInfoDto>>(courseName, dtos);
        }
     }
}