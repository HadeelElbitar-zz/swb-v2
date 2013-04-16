

namespace WebsiteSUPPORTASU.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSUPPORTASU.Models;
    public class SupportiansController : Controller
    {
        WebsiteSUPPORTASUCore.SupportiansService obj;
        
        public SupportiansController ()
        {
            obj = new WebsiteSUPPORTASUCore.SupportiansService();   
        }
        
        // GET: /Member/

        public ActionResult Index()
        {
            return View();
        }

    }
}
