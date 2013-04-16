

namespace WebsiteSUPPORTASU.Controllers
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSUPPORTASU.Models;
using WebsiteSUPPORTASUCore;

    public class ContactUSController : Controller
    {

        ContactUsService core;

        public ContactUSController()
        {
            core = new ContactUsService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.ContactUS contact)
        {
                if (ModelState.IsValid)
                {
                    core.AddContactUs(contact.FullName, contact.Email, contact.Subject, contact.Message);
                }
                return View("../Shared/Thanks");
         
        }
       
    }
}
