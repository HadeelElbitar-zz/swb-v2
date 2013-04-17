
namespace WebsiteSUPPORTASU.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUCore;
    using WebsiteSUPPORTASUDomain;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        StaticPageService Core;
        GalleryService GalleryCore;
        AdminService objAdmin;

        public HomeController()
        {
            Core = new StaticPageService();
            GalleryCore = new GalleryService();
            objAdmin = new AdminService();
        }

        public ActionResult Index()
        {
            ViewBag.Slider = GalleryCore.getEventGallery(11, "slider").ToList();
            ViewBag.Home = Core.GetStaticPage("Home").FirstOrDefault().Content;
            return View();
        }


        /**********  StaticPage ************/
        //
        // GET: /AboutUs/Add
        [Authorize(Users = "admin")]
        public ActionResult AddStaticPage()
        {
            return View();
        }

        //
        // POST: /StaticPage/Add

        [HttpPost]
        public ActionResult AddStaticPage(StaticPagesModel page)
        {
            if (ModelState.IsValid)
            {
                objAdmin.StaticPageCore.AddStaticPage(page.Name, page.Content);
                return RedirectToAction("AddStaticPage");
            }
            else
            {
                return View(page);
            }


        }

        //
        // GET: /AboutUs/Edit/5

        [Authorize(Users = "Admin")]
        public ActionResult EditStaticPage()
        {
            ViewBag.ElementsNames = objAdmin.StaticPageCore.GetStaticPages().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /AboutUs/Edit/5

        [HttpPost]
        public ActionResult EditStaticPage(StaticPagesModel Page, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Page.ID;
                objAdmin.StaticPageCore.EditStaticPage(ID, Page.Name, Page.Content);
                return RedirectToAction("EditStaticPage");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                StaticPage ePage = objAdmin.StaticPageCore.GetStaticPageByID(ID).FirstOrDefault();
                Page.ID = ID;
                Page.Name = ePage.Name;
                Page.Content = ePage.Content;
                return View("EditStaticPage", Page);
            }
        }

        //
        // GET: /AboutUs/Delete/5

        [Authorize(Users = "Admin")]
        public ActionResult DeleteStaticPage()
        {
            ViewBag.ElementsNames = objAdmin.StaticPageCore.GetStaticPages().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /AboutUs/Delete/5

        [HttpPost]
        public ActionResult DeleteStaticPage(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.StaticPageCore.DeleteStaticPage(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DeleteStaticPage");
            }

        }


    }
}
