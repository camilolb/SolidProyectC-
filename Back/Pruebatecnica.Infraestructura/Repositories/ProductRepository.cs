using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly DatabaseContext _dbContext;

        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await Get(id);
            _dbContext.Product.Remove(current);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<Product> Get(int id)
        {
            var response = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        public async Task<IEnumerable<Product>> Gets()
        {
            var response = await _dbContext.Product.ToListAsync();
            return response;
        }

        public async Task Insert(Product item)
        {
            _dbContext.Product.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(Product item)
        {
            var current = await Get(item.Id);
            current.Name = item.Name;

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
