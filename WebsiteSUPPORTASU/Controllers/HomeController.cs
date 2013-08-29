
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
            ViewBag.Home = Core.GetStaticPage("Home").FirstOrDefault().Content;
            return View();
        }

    }
}
