

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
        AdminService objAdmin;

        public ContactUSController()
        {
            core = new ContactUsService();
        objAdmin = new AdminService();
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

        /****** Contact US ******/

        [Authorize(Users = "Admin")]
        public ActionResult DeleteContact()
        {
            ViewBag.ElementsNames = objAdmin.ContactUsCore.GetContacts().ToList();
            return View("SelectDelete");
        }

        //[HttpPost]
        //public ActionResult Edit(int id, ContactUS contact)
        //{
        //    WebsiteSUPPORTASUCore.ContactUsService EditContact = new WebsiteSUPPORTASUCore.ContactUsService();
        //    EditContact.Ed(contact.Name, contact.Email, contact.Subject, contact.Message);
        //    return View("Updated");
        //}

        [HttpPost]
        public ActionResult DeleteContact(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.ContactUsCore.DeleteContact(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DeleteContact");
            }
        }

    }
}
