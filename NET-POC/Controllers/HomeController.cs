using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_POC.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            using (Models.DataContexts db = new Models.DataContexts())
            {
                db.Users.ToList();
            }
            return View();
        }
    }
}