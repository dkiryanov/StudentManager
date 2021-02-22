using System;

namespace DAL.Entities
{
    public abstract class CourseInfo
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public string StudentScore { get; set; }

        public string CourseName { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? ExportedDate { get; set; }
    }
}