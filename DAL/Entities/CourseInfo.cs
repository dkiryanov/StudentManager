using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class CourseInfo
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public string StudentName { get; set; }

        public int StudentScore { get; set; }

        public string CourseName { get; set; }

        public DateTime AddedDate { get; set; }
    }
}