using Microsoft.AspNetCore.Mvc;

namespace Сhat_on_SignalR.Controllers
{
    /// <summary>
    /// Main controller to handle general requests from users
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the main page for users
        /// </summary>
        /// <returns>Main page</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}