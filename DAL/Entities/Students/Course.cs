using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Students
{
    public class Course
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public string Name { get; set; }

        //public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
