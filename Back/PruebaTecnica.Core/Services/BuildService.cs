using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;


namespace PruebaTecnica.Core.Services
{
    public class BuildService : IBuildService
    {

        //private readonly IBuildRepository _buildRepository;

        private readonly IRepository<Build> _buildRepository;


        public BuildService(IRepository<Build> buildRepository)
        {
            _buildRepository = buildRepository;
        }

        

        public async Task<Build> Get(int id)
        {
            return await _buildRepository.GetById(id);
        }

        public IEnumerable<Build> Gets()
        {
            return _buildRepository.GetAll();
        }

        public async Task Insert(Build item)
        {
            await _buildRepository.Add(item);
        }

        public void Update(Build item)
        {
            _buildRepository.Update(item);
        }

        public async Task Delete(int id)
        {
            await _buildRepository.Delete(id);
        }

    }
}
