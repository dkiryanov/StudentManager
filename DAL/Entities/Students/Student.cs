using System.Collections.Generic;

namespace DAL.Entities.Students
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        public virtual ICollection<AcademicPerformance> Enrollments { get; set; } = new List<AcademicPerformance>();
    }
}