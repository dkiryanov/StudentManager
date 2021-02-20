using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Entities.Students;

namespace DAL.UoW
{
    /// <summary>
    /// Implementation of the unit of work pattern.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly StudentsContext _context;

        public UnitOfWork()
        {
            _context = new StudentsContext();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}