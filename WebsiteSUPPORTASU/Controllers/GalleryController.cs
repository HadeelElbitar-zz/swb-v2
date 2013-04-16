
namespace WebsiteSUPPORTASU.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUCore;


    using Gallery = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Gallery>;
    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;

    public class GalleryController : Controller
    {


        //
        // GET: /Gallery/

        WebsiteSUPPORTASUCore.GalleryService GalleryCore;
        WebsiteSUPPORTASUCore.EventService EventCore;

        
        public GalleryController()
        {
            GalleryCore = new GalleryService();
            EventCore = new EventService();
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
            Gallery objGallery = GalleryCore.getEventGallery(ID, "Image");
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

    }
}
