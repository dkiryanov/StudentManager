using System;

namespace BLL.DTO
{
    public class CourseInfoDto
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public string StudentScore { get; set; }

        public string CourseName { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? ExportedDate { get; set; }
    }
}
