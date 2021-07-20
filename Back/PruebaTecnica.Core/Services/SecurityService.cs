using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
namespace PruebaTecnica.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        

        public SecurityService(ISecurityRepository userRepository)
        {
            _securityRepository = userRepository;
        }

        public async Task<Security> Get(int id)
        {
            return await _securityRepository.Get(id);
        }



        public async Task<Security> Get(string userName, string password)
        {
            var res = await _securityRepository.Get(userName);

            var validate = !BCrypt.Net.BCrypt.Verify(password, res.Password);
            if (validate)
            {
            }

            var user = await _securityRepository.Get(userName, res.Password);
            return user;
        }

        private async Task<Security> Get(string email)
        {

            var res = await _securityRepository.Get(email);
            return await _securityRepository.Get(email);

        }

        public async Task Insert(Security item)
        {
            item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
            await _securityRepository.Insert(item);
        }

        public async Task<bool> Update(Security item)
        {
            if (!string.IsNullOrEmpty(item.Password))
            {
                item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
            }

            var product = await _securityRepository.Get(item.Id);
            return await _securityRepository.Update(product);
        }


        public async Task<bool> Delete(int id)
        {
            return await _securityRepository.Delete(id);
        }

    }
}
