using System;
using System.Collections.Generic;
using DAL.UoW;

namespace BLL.Factories
{
    public class CourseInfoUoWFactory : ICourseInfoUoWFactory
    {
        private readonly IDictionary<string, ICourseInfoUnitOfWork> _settings;

        public CourseInfoUoWFactory(IUnitOfWork uow)
        { 
            _settings = new Dictionary<string, ICourseInfoUnitOfWork>()
            {
                { "информатика", uow.History },
                { "математика", uow.Maths },
                { "история", uow.Informatics }
            };
        }

        public ICourseInfoUnitOfWork GetUnitOfWork(string courseName)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentNullException();
            }

            ICourseInfoUnitOfWork uow;
            _settings.TryGetValue(courseName.Trim().ToLower(), out uow);

            return uow;
        }
    }
}