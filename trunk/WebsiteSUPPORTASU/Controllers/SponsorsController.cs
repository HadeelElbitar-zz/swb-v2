
namespace WebsiteSUPPORTASU.SponsorsControllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUDomain;
    using WebsiteSUPPORTASUCore;

    using Sponsor = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.SponsorView>;
    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;

    public class SponsorsController : Controller
    {

        WebsiteSUPPORTASUCore.SponsorService SponsorCore;
        WebsiteSUPPORTASUCore.EventService EventCore;

        //
        // GET: /Sponser/

        public SponsorsController()
        {
            SponsorCore = new SponsorService();
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
            Sponsor objSponsor = SponsorCore.GetEventSponsors("2", ID);
            //if(objGallery.FirstOrDefault() != null)
            ViewBag.CurrentEventAcademic = objSponsor.ToList();
            objSponsor = SponsorCore.GetEventSponsors("1", ID);
            //if (objGallery.FirstOrDefault() != null)
            ViewBag.CurrentEventMain = objSponsor.ToList();
            foreach (var x in ViewBag.CurrentEventMain)
            {
                var y = x;
            }
            return PartialView("Sponsors");
        }


    }
}
