using System.Data.Entity;
using DAL.Entities.Students;

namespace DAL.Repositories.Implementations
{
    public class StudentRepository : CommonRepository<Student>
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }
    }
}
