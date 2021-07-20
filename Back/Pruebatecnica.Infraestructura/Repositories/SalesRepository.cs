using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class SalesRepository: ISalesRepository
    {
        private readonly DatabaseContext _dbContext;

        public SalesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await Get(id);
            _dbContext.Sales.Remove(current);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<Sales> Get(int id)
        {
            var response = await _dbContext.Sales.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        public async Task<IEnumerable<Sales>> Gets()
        {
            var response = await _dbContext.Sales.Include(x => x.Product).ToListAsync();
            return response;
        }

        public async Task Insert(Sales item)
        {
            _dbContext.Sales.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(Sales item)
        {
            var current = await Get(item.Id);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
