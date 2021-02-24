using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories.Implementations
{
    internal class MathsRepository : CommonRepository<CourseInfo>
    {
        public MathsRepository(DbContext context) : base(context)
        {
        }
    }
}
