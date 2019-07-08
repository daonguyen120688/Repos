using Microsoft.EntityFrameworkCore;
using System;

namespace FirstApp.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
    }
}
