
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


    using System.Web.Security;

    [Authorize(Users = "admin")]
    public class EventsController : Controller
    {
        WebsiteSUPPORTASUCore.EventService EventsCore;
        AdminService objAdmin;
        GalleryService GalleryCore;

        public EventsController()
        {
            EventsCore = new EventService();
            objAdmin = new AdminService();
            GalleryCore = new GalleryService();
        }

        //
        // GET: /Events/

        public ActionResult Index()
        {
            ViewBag.EventsList = EventsCore.GetEvents().OrderBy(X => X.StartDate.Year).Reverse().ToList();
            //ViewBag.EventsList.OrderBy(X => X.StartDate);
            ViewBag.Slider = GalleryCore.getPageGallery("events", "slider").ToList();
            return View();
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int Id)
        {
            ViewBag.Event = EventsCore.GetEvent(Id).FirstOrDefault();
            ViewBag.EventsList = EventsCore.GetEvents().OrderBy(X => X.StartDate.Year).Reverse().ToList();
            ViewBag.Slider = GalleryCore.getPageGallery("subevent", "slider").ToList();
            return View();
        }

        public ActionResult GetPartialView(int ID)
        {
            WebsiteSUPPORTASUDomain.Event Event = EventsCore.GetEvent(ID).FirstOrDefault();
            ViewBag.Description = Event.Description;
            return PartialView("Description");

        }

        public string GetEventName(int ID)
        {
            return EventsCore.GetEventsNames().ToList().Find(x => x.ID == ID).Name;
        }


        // GET: /Events/Add
        [ValidateInput(false)]
        [Authorize(Users = "Admin")]
        public ActionResult AddEvent()
        {
            return View();
        }

        //
        // POST: /Events/Add
        [ValidateInput(false)]
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
        [ValidateInput(false)]
        [Authorize(Users = "Admin")]
        public ActionResult EditEvent()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View("../Admin/SelectEdit");
        }

        //
        // POST: /Events/Edit/5
        [ValidateInput(false)]
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
                int ID = int.Parse(form["Elements"]) == null ? Event.ID : int.Parse(form["Elements"]);
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
        [ValidateInput(false)]
        [Authorize(Users = "Admin")]
        public ActionResult DeleteEvent()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View("../Admin/SelectDelete");
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
