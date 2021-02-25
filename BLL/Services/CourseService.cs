using System;
using System.Linq;
using BLL.Services.Interfaces;
using DAL.Entities.Students;
using DAL.UoW;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;

        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Course GetCourseByName(string courseName)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentNullException();
            }

            Course existingCourse = _uow
                .Students
                .Courses
                .Find(x => x.Name.Equals(courseName))?.FirstOrDefault();

            return existingCourse ?? new Course()
            {
                Name = courseName
            };
        }
    }
}
