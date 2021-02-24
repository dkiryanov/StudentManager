using System;
using DAL.Entities;
using DAL.Entities.Students;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public class StudentsUnitOfWork : BaseUnitOfWork<StudentsContext>
    {
        public override void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public StudentsUnitOfWork(StudentsContext context) : base(context)
        {
        }

        public ICommonRepository<CourseInfo> CourseInfos { get; }
    }
}
