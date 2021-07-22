using System.Threading.Tasks;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        private readonly IRepository<Build> _buildRepository;
        private readonly IRepository<Departament> _departamentRepository;
        private readonly IRepository<Owner> _ownerRepository;
        
        
        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Build> BuildRepository => _buildRepository ?? new BaseRepository<Build>(_dbContext);
        public IRepository<Departament> DepartamentRepository => _departamentRepository ?? new BaseRepository<Departament>(_dbContext);
        public IRepository<Owner> OwnerRepository => _ownerRepository ?? new BaseRepository<Owner>(_dbContext);


        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
