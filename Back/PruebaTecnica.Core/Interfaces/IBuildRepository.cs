using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
namespace PruebaTecnica.Core.Interfaces
{
    public interface IBuildRepository
    {

        Task<IEnumerable<Build>> Gets();
        Task<Build> Get(int id);
        Task Insert(Build item);
        Task<bool> Update(Build item);
        Task<bool> Delete(int id);
    }
}



