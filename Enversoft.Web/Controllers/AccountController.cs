using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Enversoft.Web.Security;
using System.Security.Claims;

namespace Enversoft.Web.Controllers
{
    [CustomAuthorization]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewBag.UserString=User.FindFirstValue(ClaimTypes.Role);
            return View();
        }
    }
}
