
namespace WebsiteSUPPORTASU.SponsorsControllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUDomain;
    using WebsiteSUPPORTASUCore;
    using WebsiteSUPPORTASU.Models;

    using vSponsor = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.SponsorView>;
    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;

    public class SponsorsController : Controller
    {

        WebsiteSUPPORTASUCore.SponsorService SponsorCore;
        WebsiteSUPPORTASUCore.EventService EventCore;
        AdminService objAdmin;

        //
        // GET: /Sponser/

        public SponsorsController()
        {
            SponsorCore = new SponsorService();
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
            vSponsor objSponsor = SponsorCore.GetEventSponsors("2", ID);
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

        /******** Sponsors *********/

        //
        // GET: /Sponser/Add

        [Authorize(Users = "Admin")]
        public ActionResult AddSponsor()
        {
            //Get The Default View For Making Addition (text box .. etc);
            return View();
        }

        //
        // POST: /Sponser/Add

        [HttpPost]
        public ActionResult AddSponsor(SponsorModel Sponsor)
        {
            try
            {
                // TODO: Add insert logic here
                objAdmin.SponsorCore.AddSponsor(Sponsor.Name, Sponsor.Website, Sponsor.Email, Sponsor.Mobile, Sponsor.Type);
                return RedirectToAction("AddSponsor");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sponser/Edit/5
        // Edit My Database (Access For Members Only) 
        [Authorize(Users = "Admin")]
        public ActionResult EditSponsor()
        {
            ViewBag.ElementsNames = objAdmin.SponsorCore.GetSponsors().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /Sponser/Edit/5

        [HttpPost]
        public ActionResult EditSponsor(SponsorModel Sponsor, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Sponsor.ID;
                objAdmin.SponsorCore.EditSponsor(ID, Sponsor.Name, Sponsor.Website, Sponsor.Email, Sponsor.Mobile, Sponsor.Type);
                return RedirectToAction("EditSponsor");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                Sponsor eSponsor = objAdmin.SponsorCore.GetSponsor(ID).FirstOrDefault();
                Sponsor.ID = ID;
                Sponsor.Name = eSponsor.Name;
                Sponsor.Website = eSponsor.Website;
                Sponsor.Email = eSponsor.Email;
                Sponsor.Mobile = eSponsor.ContactNumber;
                Sponsor.Type = eSponsor.Comments;
                return View("EditSponsor", Sponsor);
            }
        }

        //
        // GET: /Sponser/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult DeleteSponsor()
        {
            ViewBag.ElementsNames = objAdmin.SponsorCore.GetSponsors().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /Sponser/Delete/5

        [HttpPost]
        public ActionResult DeleteSponsor(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.SponsorCore.DeleteSponsor(id);
                return RedirectToAction("DeleteSponsor");
            }
            catch
            {
                return View();
            }
        }


    }
}
