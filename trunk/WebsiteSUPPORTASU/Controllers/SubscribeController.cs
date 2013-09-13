
namespace WebsiteSUPPORTASU.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASU.Models;
    using WebsiteSUPPORTASUCore;

    using System.Web.Security;

    //[Authorize(Users = "admin")]
    public class SubscribeController : Controller
    {
        SubscribeService core;

        public SubscribeController()
        {
            core = new SubscribeService();
        }

        [HttpPost]
        public bool AddSubscribe(Subscribe subscribe)
        {
            return core.AddSubscribe(subscribe.Name, subscribe.Email, 0);
        }
       
        public ActionResult GetSubscribe(int id)
        {
            ViewBag.ElementsNames = core.GetSubscribe(id);
            return View();

        }
         
        public ActionResult Edit(int id,int state)
        {
              //core.EditSubscribe(id, state);
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            core.DeleteSubscribe(id);
            return View();
        }
    }
}
