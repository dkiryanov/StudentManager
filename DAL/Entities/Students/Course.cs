using System.Collections.Generic;

namespace DAL.Entities.Students
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public virtual ICollection<AcademicPerformance> Enrollments { get; set; } = new List<AcademicPerformance>();
    }
}
