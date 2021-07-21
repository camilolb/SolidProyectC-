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
        

        public SalesService(ISalesRepository salesRepository
            )
        {
            _salesRepository = salesRepository;
            
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
            
            await _salesRepository.Insert(item);
        }

        public async Task<bool> Update(Sales item)
        {
            return await _salesRepository.Update(item);
        }
    }
}
