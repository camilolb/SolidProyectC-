using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
namespace PruebaTecnica.Core.Interfaces
{
    public interface IDepartamentService
    {
        IEnumerable<Departament> Gets();
        Task<Departament> Get(int id);
        Task Insert(Departament item);
        void Update(Departament item);
        IEnumerable<Departament> DepartamentAndOwner(int id);
    }
}
