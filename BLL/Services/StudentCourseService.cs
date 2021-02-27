using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.UoW;

namespace BLL.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IUnitOfWork _uow;

        public StudentCourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<StudentPerformanceDto> GetStudentPerformance()
        {
            return _uow
                .Students
                .StudentCourses
                .GetAll(null, x => x.Student)
                .GroupBy(g => g.Student.Name, r => r.Score)
                .Select(g => new StudentPerformanceDto()
                {
                    StudentName = g.Key,
                    AverageScore = g.Average()
                })
                .ToList();
        }
    }
}
