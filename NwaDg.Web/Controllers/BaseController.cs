using System.Web.Mvc;

namespace NwaDg.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.Title = "Northwest Arkansas Developers Group";
        }
    }
}