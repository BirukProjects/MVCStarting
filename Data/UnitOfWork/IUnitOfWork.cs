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
    public interface IUnitOfWork : IDisposable
    {

        Database Database { get; }
        IGenericRepository<Software> SoftwareRepository { get; }
        IGenericRepository<Developer> DeveloperRepository { get; }
        void Save();
    }
}


