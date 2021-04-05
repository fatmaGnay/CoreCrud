using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChange();
        IRepository<T> GetRepository<T>() where T : class;
    }
}
