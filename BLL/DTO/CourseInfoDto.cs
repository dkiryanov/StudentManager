using System;

namespace BLL.DTO
{
    public class CourseInfoDto
    {
        public string StudentName { get; set; }

        public int StudentScore { get; set; }

        public string CourseName { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? ExportedDate { get; set; }
    }
}
