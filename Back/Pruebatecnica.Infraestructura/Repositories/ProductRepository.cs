using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class BuildRepository : IBuildRepository
    {

        private readonly DatabaseContext _dbContext;

        public BuildRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await Get(id);
            _dbContext.Build.Remove(current);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<Build> Get(int id)
        {
            var response = await _dbContext.Build.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        public async Task<IEnumerable<Build>> Gets()
        {
            var response = await _dbContext.Build.ToListAsync();
            return response;
        }

        public async Task Insert(Build item)
        {
            _dbContext.Build.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(Build item)
        {
            var current = await Get(item.Id);
            current.Name = item.Name;

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
