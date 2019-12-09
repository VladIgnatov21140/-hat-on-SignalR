using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    /// <summary>
    /// Class with data layer services
    /// </summary>
    public class DataServices : IDataServices
    {
        /// <summary>
        /// Method for adding user in database
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        /// <param name="name">User's name</param>
        public async Task CreateUserAsync(string login, Guid password, string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Database.ExecuteSqlRawAsync($"INSERT INTO Users (Login, Password, Name) Values ('{login}', '{password}', '{name}');");
            }
        }

        /// <summary>
        /// Method for deletting user from database appropriate inputted a user's index
        /// </summary>
        /// <param name="userid">User's index</param>
        public async Task DeleteUserAsync(int userid)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Database.ExecuteSqlRawAsync($"DELETE Users WHERE Id = {userid};");
            }
        }

        /// <summary>
        /// Method for getting users' data from a database appropriate inputted a login and password
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task<User> GetUserAsync(string login, Guid password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dTOUser = await db.Users.FromSqlRaw($"SELECT TOP 1 * FROM Users WHERE Login = '{login}' AND Password = '{password}';").ToListAsync();
                return dTOUser.FirstOrDefault();
            }
        }

        /// <summary>
        /// Method for getting users' data from a database appropriate inputted a login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task<User> GetUserAsync(string login)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dTOUser = await db.Users.FromSqlRaw($"SELECT TOP 1 * FROM Users WHERE Login = '{login}';").ToListAsync();
                return dTOUser.FirstOrDefault();
            }
        }

        /// <summary>
        /// Method for updating user's password in a database appropriate inputted a user's login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task UpdateUserPasswordAsync(string login, Guid password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Database.ExecuteSqlRawAsync(
                    $"UPDATE Users SET Password = '{password}' WHERE Login = {login};"
                );
            }
        }

        /// <summary>
        /// Method for updating user's name in a database appropriate inputted a user's login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="name">User's name</param>
        public async Task UpdateUserNameAsync(string login, string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Database.ExecuteSqlRawAsync(
                    $"UPDATE Users SET Name = '{name}' WHERE Login = {login};"
                );
            }
        }
    }
}
