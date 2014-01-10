using System.Linq;
using System.Web.Mvc;
using NwaDnug.Web.Models;
using NwaDnug.Web.Services;

namespace NwaDnug.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel
                                    {
                                        Events = _eventService.GetEvents(),
                                        Meetings = _eventService.GetMeetings()
                                    };
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Learn()
        {
            return View();
        }
        public ActionResult Connect()
        {
            return View();
        }
        public ActionResult Teach()
        {
            return View();
        }
    }
}
