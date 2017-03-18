using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NET_POC.Models;

namespace NET_POC.Controllers
{
    [RoutePrefix("Account")]
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}