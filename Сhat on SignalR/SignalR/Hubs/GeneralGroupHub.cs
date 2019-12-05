using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Сhat_on_SignalR.SignalR.Hubs
{
    /// <summary>
    /// Hub to handle requests from shared group users
    /// </summary>
    public class GeneralGroupHub : Hub
    {
        private static IBusinessServices BusinessServices { get; set; }

        /// <summary>
        /// Get and set businessServices
        /// </summary>
        /// <param name="businessServices"></param>
        public GeneralGroupHub(IBusinessServices businessServices)
        {
            BusinessServices = businessServices;
        }

        /// <summary>
        /// Method for autentification user
        /// </summary>
        /// <param name="userLogin">User login</param>
        /// <param name="userPassword">User password</param>
        /// <returns>If the user was found in a database then for him will
        /// be caused SetUserName and return user's name else UserNotFound.</returns>
        public async Task Login(string userLogin, string userPassword)
        {
            DTOUser User = await BusinessServices.ValidateUserPasswordAsync(userLogin, userPassword);
            if (User.Login != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "GeneralGroup");
                await Clients.Caller.SendAsync("SetUserName", User.Name.ToString());
            }
            else
                await Clients.Caller.SendAsync("UserNotFound");
        }

        /// <summary>
        /// Method for registration a user
        /// </summary>
        /// <param name="userLogin">User login</param>
        /// <param name="userPassword">User password</param>
        /// <param name="userName">User name</param>
        /// <returns>If the user login was found in a database then for he will register.
        /// Be caused Registered and return user's login, password and name else LoginIsDefined.</returns>
        public async Task Register(string userLogin,  string userPassword, string userName)
        {
            if (await BusinessServices.RegisterUserAsync(userLogin, userPassword, userName))
                await Clients.Caller.SendAsync("Registered", userLogin, userName);
                else
                    await Clients.Caller.SendAsync("LoginIsDefined");
        }

        /// <summary>
        /// Handles sending messages
        /// </summary>
        /// <param name="message">Message from user</param>
        /// <param name="userName">User name</param>
        /// <returns>Send message to all users from the general group</returns>
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Send", message, userName);
        }
    }
}
