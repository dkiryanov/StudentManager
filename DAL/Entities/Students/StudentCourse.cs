using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Students
{
    public class StudentCourse
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Key, Column(Order = 1)]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Index]
        public int Score { get; set; }
    }
}