using System.Data.Entity;
using DAL.Entities.Students;

namespace DAL.Repositories.Implementations
{
    public class StudentCourseRepository : CommonRepository<StudentCourse>
    {
        public StudentCourseRepository(DbContext context) : base(context)
        {
        }
    }
}