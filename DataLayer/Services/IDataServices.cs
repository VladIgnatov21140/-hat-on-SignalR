using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    /// <summary>
    /// Data layer services
    /// </summary>
    public interface IDataServices
    {
        /// <summary>
        /// Method for getting users' data in list from a database appropriate inputted a login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public Task<List<User>> GetUserAsync(string login);

        /// <summary>
        /// Method for getting users' data in list from a database appropriate inputted a login and password
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public Task<List<User>> GetUserAsync(string login, Guid password);

        /// <summary>
        /// Method for updating user's password in a database appropriate inputted a user's login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public Task UpdateUserPasswordAsync(string login, Guid password);

        /// <summary>
        /// Method for updating user's name in a database appropriate inputted a user's login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="name">User's name</param>
        public Task UpdateUserNameAsync(string login, string name);

        /// <summary>
        /// Method for adding user in database
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        /// <param name="name">User's name</param>
        public Task CreateUserAsync(string login, Guid password, string name);

        /// <summary>
        /// Method for deletting user from database appropriate inputted a user's index
        /// </summary>
        /// <param name="userid">User's index</param>
        public Task DeleteUserAsync(int userid);
    }
}
