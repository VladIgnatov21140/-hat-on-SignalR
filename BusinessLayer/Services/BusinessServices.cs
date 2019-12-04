using BusinessLayer.Models;
using DataLayer.Models;
using DataLayer.Services;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Class for using with data layer
    /// </summary>
    public class BusinessServices : IBusinessServices
    {
        /// <summary>
        /// Data layer services
        /// </summary>
        private static IDataServices DataServices { get; set; }

        /// <summary>
        /// Getting data layer services
        /// </summary>
        /// <param name="dataServices">Data layer services</param>
        public BusinessServices(IDataServices dataServices)
        {
            DataServices = dataServices;
        }

        /// <summary>
        /// Method to verify user password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>User's data</returns>
        public async Task<BUser> ValidateUserPasswordAsync(string login, string password)
        {
            var User = await DataServices.GetUserAsync(login, new Guid(password.MD5Cryptography()));
            if (User.Count > 0)
                return new BUser
                {
                    Id = User[0].Id,
                    Login = User[0].Login,
                    Password = User[0].Password,
                    Name = User[0].Name
                };
            else
                return new BUser { };

        }

        /// <summary>
        /// Method for update user's data
        /// </summary>
        /// <param name="userid">User id</param>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <param name="name">User name</param>
        public async Task UpdateUserAsync(int userid, string login, string password, string name)
        {
            await DataServices.UpdateUserAsync(userid, login, new Guid(password.MD5Cryptography()), name);
        }

        /// <summary>
        /// Method for register user
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <param name="name">User name</param>
        /// <returns>If input user login was not found in registered users
        /// then user data will write. Will return true and else return false.</returns>
        public async Task<bool> RegisterUserAsync(string login, string password, string name)
        {
            Guid GuidPassword = new Guid(password.MD5Cryptography());
            var User = await DataServices.GetUserAsync(login);
            if (User.Count == 0)
            {
                await DataServices.AddUserAsync(login, GuidPassword, name);
                return true;
            }   
            else
                return false;
        }

        /// <summary>
        /// Method for deleting registered user
        /// </summary>
        /// <param name="userid">User id</param>
        public async Task DeleteUserAsync(int userid)
        {
            await DataServices.DeleteUserAsync(userid);
        }
    }
}
