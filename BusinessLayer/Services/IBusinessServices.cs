using BusinessLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Business layer services
    /// </summary>
    public interface IBusinessServices
    {
        public Task<BUser> ValidateUserPasswordAsync(string login, string password);
        public Task UpdateUserAsync(int userid, string login, string password, string name);
        public Task<bool> RegisterUserAsync(string login, string password, string name);
        public Task DeleteUserAsync(int userid);
    }
}
