
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

        public HomeController()
        {
            Core = new StaticPageService();
            GalleryCore = new GalleryService();
        }

        public ActionResult Index()
        {
            //try
            //{

            //    ViewBag.Home = Core.GetStaticPage("Home").FirstOrDefault().Content;
            //    ViewBag.Slider = GalleryCore.getPageGallery("home", "slider").ToList();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}  
            return View("Index2");
        }

    }
}
