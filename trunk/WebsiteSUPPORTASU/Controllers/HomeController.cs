using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSUPPORTASUCore;

namespace WebsiteSUPPORTASU.Models
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        StaticPageService Core;
        GalleryService GalleryCore;

        public HomeController()
        {
            Core = new StaticPageService();
            GalleryCore = new GalleryService();
        }

        public ActionResult Index()
        {
            ViewBag.Slider = GalleryCore.getEventGallery(11, "slider").ToList();
            ViewBag.Home = Core.GetStaticPage("Home").FirstOrDefault().Content;
            return View();
        }

    }
}
