using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
namespace PruebaTecnica.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Gets();
        Task<Product> Get(int id);
        Task Insert(Product item);
        Task<bool> Update(Product item);
        Task<Product> GetCode(string code);
    }
}



