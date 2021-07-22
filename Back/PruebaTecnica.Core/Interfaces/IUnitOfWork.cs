using System;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Security> SecurityRepository { get; }
        IRepository<Build> BuildRepository { get;  }

        void SaveChanges();

        Task SaveChangesAsync();

    }
}
