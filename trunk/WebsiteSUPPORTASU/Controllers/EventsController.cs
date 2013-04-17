
namespace WebsiteSUPPORTASU.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUCore;
    using WebsiteSUPPORTASU.Models;
    using WebsiteSUPPORTASUDomain;

    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;

    public class EventsController : Controller
    {
        WebsiteSUPPORTASUCore.EventService EventsCore;
        AdminService objAdmin;

        public EventsController()
        {
            EventsCore = new EventService();
        objAdmin = new AdminService();
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


        // GET: /Events/Add

        [Authorize(Users = "Admin")]
        public ActionResult AddEvent()
        {
            return View();
        }

        //
        // POST: /Events/Add

        [HttpPost]
        public ActionResult AddEvent(EventModel eEvent)
        {
            if (ModelState.IsValid)
            {
                objAdmin.EventsCore.AddEvent(eEvent.Name, eEvent.StartDate, eEvent.EndDate, eEvent.FullDescription, eEvent.ShortDescrption, eEvent.Comments);
                return RedirectToAction("AddEvent");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Events/Edit/5
        [Authorize(Users = "Admin")]
        public ActionResult EditEvent()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        public ActionResult EditEvent(EventModel Event, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Event.ID;
                objAdmin.EventsCore.EditEvent(ID, Event.Name, Event.StartDate, Event.EndDate, Event.FullDescription, Event.ShortDescrption, Event.Comments);
                return RedirectToAction("EditEvent");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                Event eEvent = objAdmin.EventsCore.GetEvent(ID).FirstOrDefault();
                Event.ID = ID;
                Event.Name = eEvent.Name;
                Event.StartDate = eEvent.StartDate;
                Event.EndDate = eEvent.EndDate;
                Event.FullDescription = eEvent.Description;
                Event.ShortDescrption = eEvent.ShortDescription;
                Event.Comments = eEvent.Comments;
                return View("EditEvent", Event);
            }
        }

        //
        // GET: /Events/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult DeleteEvent()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /Events/Delete/5

        [HttpPost]
        public ActionResult DeleteEvent(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.EventsCore.DeleteEvent(id);
                return RedirectToAction("DeleteEvent");
            }
            catch
            {
                return View("SelectDelete");
            }
        }

    }
}
