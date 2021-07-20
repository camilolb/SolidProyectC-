using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using System.Linq;


namespace PruebaTecnica.Core.Services
{
    public class ProductService : IProductService 
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<bool> Delete(int id)
        {
            return await _productRepository.Delete(id);
        }

        public async Task<Product> Get(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<Product> GetCode(string code)
        {
            var getCode = await Gets();
            var res = getCode.Where(x => x.Code == code).FirstOrDefault();

            return res;
        }

        public async Task<IEnumerable<Product>> Gets()
        {
            return await _productRepository.Gets();
        }

        public async Task Insert(Product item)
        {

            await _productRepository.Insert(item);
        }

        public async Task<bool> Update(Product item)
        {
            return await _productRepository.Update(item);
        }


    }
}
