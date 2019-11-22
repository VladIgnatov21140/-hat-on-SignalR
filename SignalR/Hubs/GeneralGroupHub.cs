using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Сhat_on_SignalR.SignalR.Hubs
{
    /// <summary>
    /// Hub to handle requests from shared group users
    /// </summary>
    public class GeneralGroupHub : Hub
    {
        /// <summary>
        /// Handles sending messages
        /// </summary>
        /// <param name="message">Message from user</param>
        /// <param name="userName">User name</param>
        /// <returns>Sends message to all users from the general group</returns>
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Send", message, userName);
        }
    }
}
