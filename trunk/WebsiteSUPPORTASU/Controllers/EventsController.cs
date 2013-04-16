
namespace WebsiteSUPPORTASU.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUCore;
    using WebsiteSUPPORTASU.Models;

    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;

    public class EventsController : Controller
    {
        WebsiteSUPPORTASUCore.EventService EventsCore;

        public EventsController()
        {
            EventsCore = new EventService();
        }

        //
        // GET: /Events/

        public ActionResult Index()
        {
            ViewBag.EventsList = EventsCore.GetEvents().OrderBy(X => X.StartDate.Year).Reverse().ToList();
            //ViewBag.EventsList.OrderBy(X => X.StartDate);
            return View();
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int Id)
        {
            ViewBag.Event = EventsCore.GetEvent(Id).FirstOrDefault() ;
            return View();
        }

        public ActionResult GetPartialView(int ID)
        {
            int mod = (int)(Math.Pow(10.0, (double)ID.ToString().Count()-1));
            int EventID = ID%mod;
            ID /= mod;
            WebsiteSUPPORTASUDomain.Event Event = EventsCore.GetEvent(EventID).FirstOrDefault();
            if (ID == 1)
            {
                ViewBag.Description = Event.Description;
                return PartialView("Description");
            }
            else if (ID == 2)
            {
                return RedirectToAction("GetPartialView", "Sponsors", new { ID = EventID });
            }
            else if (ID == 3)
            {
                return RedirectToAction("GetPartialView", "Gallery", new { ID = EventID });
            }
            else if (ID == 4)
            {
                if (Event.state == false || Event.state == null)
                    return PartialView("RegistrationClosed");
                else
                    return PartialView("Registration");
            }
            else if(ID == 5)
            {
                return PartialView("Live Streaming");
            }
            else
            {
                return PartialView("Map");
            }

        }

        public string GetEventName(int ID)
        {
            return EventsCore.GetEventsNames().ToList().Find(x => x.ID == ID).Name;
        }

    }
}
