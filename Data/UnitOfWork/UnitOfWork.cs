using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Repository;

namespace Data.UnitOfWork
{
    public class UnitsOfWork : IUnitOfWork
    {


        public Database Database { get { return _context.Database; } }
        private readonly SoftDevContext _context;

        public UnitsOfWork()
        {
            this._context = new SoftDevContext();
        }




        private IGenericRepository<Software> _softwareRepository;

        public IGenericRepository<Software> SoftwareRepository
        {
            get
            {
                return this._softwareRepository ??
                       (this._softwareRepository = new GenericRepository<Software>(_context));
            }
        }

        private IGenericRepository<Developer> _developerRepository;

        public IGenericRepository<Developer> DeveloperRepository
        {
            get
            {
                return this._developerRepository ?? (this._developerRepository = new GenericRepository<Developer>(_context));
            }

        }




        public void Save()
        {
            this._context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}



