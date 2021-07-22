using System;
using System.Threading.Tasks;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        private readonly IRepository<Security> _securityRepository;
        private readonly IRepository<Build> _buildRepository;


        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Security> SecurityRepository => _securityRepository ?? new BaseRepository<Security>(_dbContext);

        public IRepository<Build> BuildRepository => _buildRepository ?? new BaseRepository<Build>(_dbContext);

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
