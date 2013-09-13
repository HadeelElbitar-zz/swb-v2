namespace WebsiteSUPPORTASU.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASUCore;
    using WebsiteSUPPORTASU.Models;
    using System.Web.Security;

    [Authorize(Users="admin")]
    //B8697DF0_0FFA_4C3F_A035_FB35DB6D23AD_
    public class AboutUsController : Controller
    {
        StaticPageService Core;
        GalleryService GalleryCore;

        public AboutUsController()
        {
            Core = new StaticPageService();
            GalleryCore = new GalleryService();
        }

        //
        // GET: /AboutUs/

        public ActionResult Index()
        {
            ViewBag.AboutUs = Core.GetStaticPage("AboutUs").FirstOrDefault().Content;
            ViewBag.AboutUs2 = Core.GetStaticPage("AboutUs2").FirstOrDefault().Content;
            ViewBag.Slider = GalleryCore.getPageGallery("aboutus", "slider").ToList();
            return View();
        }

    }

}