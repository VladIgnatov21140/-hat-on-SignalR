using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public interface IDataServices
    {
        public Task<List<DTOUser>> GetUserAsync(string login);
        public Task<List<DTOUser>> GetUserAsync(string login, Guid password);
        public Task UpdateUserAsync(int userid, string login, Guid password, string name);
        public Task AddUserAsync(string login, Guid password, string name);
        public Task DeleteUserAsync(int userid);
    }
}
