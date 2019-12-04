using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class DataServices : IDataServices
    {
        public string ConnectionString { get; set; }

        public DataServices(string connectionString = "ConnectionString")
        {
            ConnectionString = connectionString;
        }

        public async Task AddUserAsync(string login, Guid password, string name)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
            {
                await db.Database.ExecuteSqlRawAsync($"INSERT INTO Users (Login, Password, Name) Values ('{login}', '{password}', '{name}');");
            }
        }

        public async Task DeleteUserAsync(int userid)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
            {
                await db.Database.ExecuteSqlRawAsync($"DELETE Users WHERE Id = {userid};");
            }
        }

        public async Task<List<DTOUser>> GetUserAsync(string login, Guid password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dTOUser = await db.Users.FromSqlRaw($"SELECT * FROM Users WHERE Login = '{login}' AND Password = '{password}';").ToListAsync();
                return dTOUser;
            }
        }

        public async Task UpdateUserAsync(int userid, string login, Guid password, string name)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
            {
                await db.Database.ExecuteSqlRawAsync(
                    $"UPDATE Users SET Login = '{login}', Password = '{password}', Name = '{name}' WHERE Id = {userid};"
                );
            }
        }

        public async Task<List<DTOUser>> GetUserAsync(string login)
        {
            using (ApplicationContext db = new ApplicationContext(ConnectionString))
            {
                var dTOUser = await db.Users.FromSqlRaw($"SELECT * FROM Users WHERE Login = '{login}';").ToListAsync();
                return dTOUser;
            }
        }
    }
}
