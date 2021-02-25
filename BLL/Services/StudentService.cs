using System;
using System.Linq;
using BLL.Services.Interfaces;
using DAL.Entities.Students;
using DAL.UoW;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Student GetStudentByName(string studentName)
        {
            if (string.IsNullOrEmpty(studentName))
            {
                throw new ArgumentNullException();
            }

            Student existingStudent = _uow
                .Students
                .Students
                .Find(x => x.Name.Equals(studentName))?.FirstOrDefault();

            return existingStudent ?? new Student()
            {
                Name = studentName
            };
        }
    }
}