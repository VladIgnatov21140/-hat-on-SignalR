using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    /// <summary>
    /// Class with data layer services
    /// </summary>
    public class DataServices : IDataServices
    {
        private ApplicationContext db;

        public DataServices(ApplicationContext context)
        {
            db = context;
        }
        /// <summary>
        /// Method for adding user in database
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        /// <param name="name">User's name</param>
        public async Task CreateUserAsync(string login, Guid password, string name)
        {
            var user = new User { Login = login, Name = name, Password = password };
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Method for deletting user from database appropriate inputted a user's index
        /// </summary>
        /// <param name="userid">User's index</param>
        public async Task DeleteUserAsync(int userid)
        {
            var user = await db.Users.SingleOrDefaultAsync(el => el.Id == userid);
            if (user != null)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Method for getting users' data from a database appropriate inputted a login and password
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task<User> GetUserAsync(string login, Guid password)
        {
            var user = await db.Users.SingleOrDefaultAsync(el => el.Login == login && el.Password == password);
            return user;
        }

        /// <summary>
        /// Method for getting users' data from a database appropriate inputted a login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task<User> GetUserAsync(string login)
        {
            var user = await db.Users.SingleOrDefaultAsync(el => el.Login == login);
            return user;
        }

        /// <summary>
        /// Method for updating user's password in a database appropriate inputted a user's login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task UpdateUserPasswordAsync(string login, Guid password)
        {
            var user = await db.Users.SingleOrDefaultAsync(el => el.Login == login);
            if (user != null)
            {
                user.Password = password;
                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Method for updating user's name in a database appropriate inputted a user's login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="name">User's name</param>
        public async Task UpdateUserNameAsync(string login, string name)
        {
            var user = await db.Users.SingleOrDefaultAsync(el => el.Login == login);
            if (user != null)
            {
                user.Name = name;
                await db.SaveChangesAsync();
            }
        }
    }
}
