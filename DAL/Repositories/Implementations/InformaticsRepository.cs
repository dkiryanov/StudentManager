using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories.Implementations
{
    internal class InformaticsRepository : CommonRepository<CourseInfo>
    {
        public InformaticsRepository(DbContext context) : base(context)
        {
        }
    }
}