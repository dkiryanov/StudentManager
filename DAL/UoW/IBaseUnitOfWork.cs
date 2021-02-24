using System;

namespace DAL.UoW
{
    public interface IBaseUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}