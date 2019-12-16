using BusinessLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Business layer services
    /// </summary>
    public interface IBusinessServices
    {
        /// <summary>
        /// Method to verify user password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>User's data</returns>
        public Task<DTOUser> GetUserAsync(string login, string password);

        /// <summary>
        /// Method for update user's password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        public Task UpdateUserPasswordAsync(string login, string password);

        /// <summary>
        /// Method for update user's name
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="name">User name</param>
        public Task UpdateUserNameAsync(string login, string name);

        /// <summary>
        /// Method for register user
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <param name="name">User name</param>
        /// <returns>If input user login was not found in registered users
        /// then user data will write. Will return true and else return false.</returns>
        public Task<bool> RegisterUserAsync(string login, string password, string name);

        /// <summary>
        /// Method for deleting registered user
        /// </summary>
        /// <param name="userid">User id</param>
        public Task DeleteUserAsync(int userid);
    }
}
