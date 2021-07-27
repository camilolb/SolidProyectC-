using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.QueryFilters;

namespace PruebaTecnica.Core.Interfaces
{
    public interface IBuildService
    {
        IEnumerable<Build> Gets(BuildQueryFilter filterQuery);
        Task<Build> Get(int id);
        Task Insert(Build item);
        void Update(Build item);
        IEnumerable<Build> BuildAndDepartaments(int id);
    }
}



