
namespace WebsiteSUPPORTASU.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUCore;
    using WebsiteSUPPORTASUDomain;


    using eGallery = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Gallery>;
    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;

    using System.Web.Security;

    [Authorize(Users = "admin")]
    public class GalleryController : Controller
    {


        //
        // GET: /Gallery/

        WebsiteSUPPORTASUCore.GalleryService GalleryCore;
        WebsiteSUPPORTASUCore.EventService EventCore;
        AdminService objAdmin;

        
        public GalleryController()
        {
            GalleryCore = new GalleryService();
            EventCore = new EventService();
        objAdmin = new AdminService();
        }

        public ActionResult Index()
        {
            EventsNames objEvent = EventCore.GetEventsNames();
            ViewBag.EventsList = objEvent.OrderBy(X => X.ID).Reverse().ToList();
            return View();
        }

        public ActionResult GetPartialView(int ID)
        {
            ViewBag.CurrentEventName = EventCore.GetEventsNames().ToList().Find(x => x.ID == ID).Name;
            eGallery objGallery = GalleryCore.getEventGallery(ID, "Image");
            ViewBag.CurrentEventImages = objGallery.ToList();
            objGallery = GalleryCore.getEventGallery(ID, "Video");
            ViewBag.CurrentEventVideos = objGallery.ToList();

            return PartialView("Gallery");
        }

        //
        // GET: /Gallery/Details/5

        public ActionResult Details(int id)
        {
          //ViewBag.eGallery =  GalleryCore.getGallery(id);
            return View();
        }

        /**********   Gallery  **************/

        //
        // GET: /Gallery/Add

        [Authorize(Users = "Admin")]
        public ActionResult AddGallery()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View();
        }

        //
        // POST: /Gallery/Add

        [HttpPost]
        public ActionResult AddGallery(GalleryModel gallery)
        {
            try
            {
                objAdmin.GalleryCore.createGallery(gallery.eventID, gallery.name, gallery.type, gallery.location, gallery.comments);
                // TODO: Add insert logic here

                return RedirectToAction("AddGallery");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Gallery/Edit/5

        [Authorize(Users = "Admin")]
        public ActionResult EditGallery()
        {
            ViewBag.ElementsNames = objAdmin.GalleryCore.getGalleryNames().ToList();
            return View("../Admin/SelectEdit");
        }

        //
        // POST: /Gallery/Edit/5

        [HttpPost]
        public ActionResult EditGallery(GalleryModel Gallery, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Gallery.ID;
                objAdmin.GalleryCore.editGallery(Gallery.eventID, Gallery.ID, Gallery.name, Gallery.type, Gallery.location, Gallery.comments);
                return RedirectToAction("EditGallery");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                Gallery eGallery = objAdmin.GalleryCore.getGallery(ID).FirstOrDefault();
                Gallery.ID = ID;
                Gallery.name = eGallery.Name;
                Gallery.type = eGallery.Type;
                Gallery.eventID = eGallery.EventID;
                Gallery.comments = eGallery.Comments;
                Gallery.location = eGallery.Location;
                return View("EditGallery", Gallery);
            }
        }

        //
        // GET: /Gallery/Delete/5

        [Authorize(Users = "Admin")]
        public ActionResult DeleteGallery()
        {
            ViewBag.ElementsNames = objAdmin.GalleryCore.getGalleryNames().ToList();
            return View("../Admin/SelectDelete");
        }

        //
        // POST: /Gallery/Delete/5

        [HttpPost]
        public ActionResult DeleteGallery(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.GalleryCore.deleteGallery(id);
                return RedirectToAction("DeleteGallery");
            }
            catch
            {
                return View();
            }
        }

    }
}
