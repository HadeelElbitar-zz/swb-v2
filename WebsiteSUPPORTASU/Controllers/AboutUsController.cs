using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSUPPORTASUCore;
using WebsiteSUPPORTASU.Models;


namespace WebsiteSUPPORTASU.Controllers
{
    //B8697DF0_0FFA_4C3F_A035_FB35DB6D23AD_
    public class AboutUsController : Controller
    {
        StaticPageService Core;
        
        public AboutUsController()
        {
            Core = new StaticPageService();
        }

        //
        // GET: /AboutUs/

        public ActionResult Index()
        {
            ViewBag.AboutUs = Core.GetStaticPage("AboutUs").FirstOrDefault().Content;
            return View();
        }

    }

}