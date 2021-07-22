using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;


namespace PruebaTecnica.Core.Services
{
    public class DepartamentService : IDepartamentService
    {

        private readonly IUnitOfWork _unitOfWork;


        public DepartamentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Departament> Get(int id)
        {
            return await _unitOfWork.DepartamentRepository.GetById(id);
        }

        public IEnumerable<Departament> Gets()
        {

            return _unitOfWork.DepartamentRepository.GetAll();
        }

        public async Task Insert(Departament item)
        {
            var validate = GetExistNumber(item);

            if (validate)
            {
                throw new System.Exception("Departament Exist");
            }

            await _unitOfWork.DepartamentRepository.Add(item);
            _unitOfWork.SaveChanges();
        }

        public void Update(Departament item)
        {
            _unitOfWork.DepartamentRepository.Update(item);
            _unitOfWork.SaveChanges();

        }

        public async Task Delete(int id)
        {
            await _unitOfWork.DepartamentRepository.Delete(id);
            _unitOfWork.SaveChanges();

        }


        private bool GetExistNumber(Departament item)
        {
            var validate = _unitOfWork.DepartamentRepository.GetAll().Where(x => x.Number == item.Number).Any();
            return validate;
        }
    }
}
