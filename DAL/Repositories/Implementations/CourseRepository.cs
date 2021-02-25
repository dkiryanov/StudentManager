using System.Data.Entity;
using DAL.Entities.Students;

namespace DAL.Repositories.Implementations
{
    public class CourseRepository : CommonRepository<Course>
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }
    }
}