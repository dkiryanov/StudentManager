using System;

namespace DAL.UoW
{
    public abstract class BaseUnitOfWork<TContext> : IBaseUnitOfWork where TContext : IDisposable
    {
        private bool _disposed;
        private readonly TContext _context;

        protected BaseUnitOfWork(TContext context)
        {
            _context = context;
        }

        public abstract void SaveChanges();

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
