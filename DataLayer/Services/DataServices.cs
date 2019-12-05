﻿using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    /// <summary>
    /// Class with data layer services
    /// </summary>
    public class DataServices : IDataServices
    {
        /// <summary>
        /// String for connection to database
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Getting and setting connection string for connection to database
        /// </summary>
        public DataServices(string connectionString = "ConnectionString")
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Method for adding user in database
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        /// <param name="name">User's name</param>
        public async Task AddUserAsync(string login, Guid password, string name)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
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
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
            {
                await db.Database.ExecuteSqlRawAsync($"DELETE Users WHERE Id = {userid};");
            }
        }

        /// <summary>
        /// Method for getting users' data in list from a database appropriate inputted a login and password
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task<List<User>> GetUserAsync(string login, Guid password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dTOUser = await db.Users.FromSqlRaw($"SELECT * FROM Users WHERE Login = '{login}' AND Password = '{password}';").ToListAsync();
                return dTOUser;
            }
        }

        /// <summary>
        /// Method for updating user's data in a database appropriate inputted a user's login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        /// <param name="name">User's name</param>
        public async Task UpdateUserAsync(string login, Guid password, string name)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
            {
                await db.Database.ExecuteSqlRawAsync(
                    $"UPDATE Users SET Login = '{login}', Password = '{password}', Name = '{name}' WHERE Login = {login};"
                );
            }
        }

        /// <summary>
        /// Method for getting users' data in list from a database appropriate inputted a login
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password in md5</param>
        public async Task<List<User>> GetUserAsync(string login)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
            {
                var dTOUser = await db.Users.FromSqlRaw($"SELECT * FROM Users WHERE Login = '{login}';").ToListAsync();
                return dTOUser;
            }
        }
    }
}
