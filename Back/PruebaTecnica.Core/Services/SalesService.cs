using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using System.Linq;
namespace PruebaTecnica.Core.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;

        public SalesService(ISalesRepository salesRepository
            , IProductRepository productRepository)
        {
            _salesRepository = salesRepository;
            _productRepository = productRepository;
        }


        public async Task<bool> Delete(int id)
        {
            return await _salesRepository.Delete(id);
        }

        public async Task<Sales> Get(int id)
        {
            return await _salesRepository.Get(id);
        }


        public async Task<IEnumerable<Sales>> Gets()
        {
            return await _salesRepository.Gets();
        }

        public async Task Insert(Sales item)
        {
            var product = await _productRepository.Get(item.ProductId);
            item.Total = ((float)product.Value * item.Quantity);
            
            await _salesRepository.Insert(item);
        }

        public async Task<bool> Update(Sales item)
        {
            return await _salesRepository.Update(item);
        }
    }
}
