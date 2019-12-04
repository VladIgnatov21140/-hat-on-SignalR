using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Сhat_on_SignalR.SignalR.Hubs
{
    /// <summary>
    /// Hub to handle requests from shared group users
    /// </summary>
    public class GeneralGroupHub : Hub
    {
        private static IBusinessServices BusinessServices { get; set; }

        public GeneralGroupHub(IBusinessServices businessServices)
        {
            BusinessServices = businessServices;
        }

        /// <summary>
        /// Method for autentification user
        /// </summary>
        /// <param name="userLogin">User login</param>
        /// <param name="userPassword">User password</param>
        /// <returns>If user was found then will </returns>
        public async Task Login(string userLogin, string userPassword)
        {
            BUser User = await BusinessServices.ValidateUserPasswordAsync(userLogin, userPassword);
            if (User.Login != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "GeneralGroup");
                await Clients.Caller.SendAsync("SetUserName", User.Name.ToString());
            }
            else
                await Clients.Caller.SendAsync("UserNotFound");
        }

        public async Task Register(string userLogin,  string userPassword, string userName)
        {
            if (await BusinessServices.RegisterUserAsync(userLogin, userPassword, userName))
                await Clients.Caller.SendAsync("Registered", userLogin, userPassword, userName);
                else
                    await Clients.Caller.SendAsync("LoginIsDefined");
                    
        }

        /// <summary>
        /// Handles sending messages
        /// </summary>
        /// <param name="message">Message from user</param>
        /// <param name="userName">User name</param>
        /// <returns>Sends message to all users from the general group</returns>
        public async Task Send(string message, string userLogin)
        {
            await Clients.All.SendAsync("Send", message, userLogin);
        }
    }
}
