using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;


namespace PruebaTecnica.Core.Services
{
    public class BuildService : IBuildService
    {

        private readonly IUnitOfWork _unitOfWork;


        public BuildService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        

        public async Task<Build> Get(int id)
        {
            return await _unitOfWork.BuildRepository.GetById(id);
        }

        public IEnumerable<Build> Gets()
        {
            return _unitOfWork.BuildRepository.GetAll();
        }

        public async Task Insert(Build item)
        {
            await _unitOfWork.BuildRepository.Add(item);
            _unitOfWork.SaveChanges();
        }

        public void Update(Build item)
        {
            _unitOfWork.BuildRepository.Update(item);
            _unitOfWork.SaveChanges();

        }

        public async Task Delete(int id)
        {
            await _unitOfWork.BuildRepository.Delete(id);
            _unitOfWork.SaveChanges();

        }

    }
}
