using System.Collections.Generic;
using System.Linq;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Entities.Students;
using DAL.UoW;

namespace BLL.Services
{
    public class ExportService : IExportService
    {
        private readonly IUnitOfWork _uow;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        private readonly List<ICourseInfoUnitOfWork> _exportSettings;

        public ExportService(IUnitOfWork uow, ICourseService courseService, IStudentService studentService)
        {
            _uow = uow;
            _courseService = courseService;
            _studentService = studentService;
            _exportSettings = new List<ICourseInfoUnitOfWork>()
            {
                _uow.History,
                _uow.Informatics,
                _uow.Maths
            };
        }

        public void ProcessExport()
        {
            CleanUp();

            foreach (ICourseInfoUnitOfWork exportUoW in _exportSettings)
            {
                List<CourseInfo> courseInfos = exportUoW
                    .CourseInfos
                    .GetAll(x => !x.ExportedDate.HasValue)
                    .ToList();

                foreach (CourseInfo courseInfo in courseInfos)
                {
                    Course course = _courseService.GetCourseByName(courseInfo.CourseName);
                    Student student = _studentService.GetStudentByName(courseInfo.StudentName);

                    _uow.Students.StudentCourses.Create(new StudentCourse()
                    {
                        Course = course.Id > 0 ? null : course,
                        CourseId = course.Id > 0 ? course.Id : 0,
                        Student = student.Id > 0 ? null : student,
                        StudentId = student.Id > 0 ? student.Id : 0,
                        Score = courseInfo.StudentScore
                    });

                    _uow.Students.SaveChanges();
                }
            }
        }

        private void CleanUp()
        {
            IEnumerable<StudentCourse> studentCources = _uow.Students.StudentCourses.GetAll().ToList();

            foreach (StudentCourse sc in studentCources)
            {
                _uow.Students.StudentCourses.Delete(sc);
            }

            _uow.Students.SaveChanges();
        }
    }
}
