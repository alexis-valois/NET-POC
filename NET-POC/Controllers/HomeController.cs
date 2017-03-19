using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_POC.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            using (Entities.EBContext db = new Entities.EBContext())
            {
                db.Users.ToList();
            }
            return View();
        }
    }
}