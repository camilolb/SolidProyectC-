using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
namespace PruebaTecnica.Core.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<Sales>> Gets();
        Task<Sales> Get(int id);
        Task Insert(Sales item);
        Task<bool> Update(Sales item);
        Task<bool> Delete(int id);
    }
}
