using System;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Build> BuildRepository { get; }
        IRepository<Departament> DepartamentRepository { get; }
        IRepository<Owner> OwnerRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();

    }
}
