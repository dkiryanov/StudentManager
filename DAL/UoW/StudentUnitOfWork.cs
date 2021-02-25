using DAL.Entities.Students;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public class StudentsUnitOfWork : BaseUnitOfWork<StudentManagerContext>, IStudentsUnitOfWork
    {
        private readonly StudentManagerContext _context;
        private ICommonRepository<Student> _studentRepository;
        private ICommonRepository<Course> _courseRepository;
        private ICommonRepository<StudentCourse> _studentCourceRepository;

        public StudentsUnitOfWork(StudentManagerContext context) : base(context)
        {
            _context = context;
        }

        public ICommonRepository<Student> Students => _studentRepository ?? (_studentRepository = new StudentRepository(_context));

        public ICommonRepository<Course> Courses => _courseRepository ?? (_courseRepository = new CourseRepository(_context));

        public ICommonRepository<StudentCourse> StudentCourses => _studentCourceRepository ?? (_studentCourceRepository = new StudentCourseRepository(_context));

        public override void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
