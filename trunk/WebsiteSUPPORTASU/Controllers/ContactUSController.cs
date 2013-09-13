

namespace WebsiteSUPPORTASU.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASU.Models;
    using WebsiteSUPPORTASUCore;

    using System.Web.Security;

    [Authorize(Users = "admin")]
    public class ContactUSController : Controller
    {

        ContactUsService core;
        AdminService objAdmin;

        public ContactUSController()
        {
            core = new ContactUsService();
            objAdmin = new AdminService();
        }


        [HttpPost]
        public ActionResult AddContact(ContactUS contact, FormCollection f)
        {
            try
                {
                    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage()
                    {
                        Subject = contact.Subject,
                        Body = contact.Message,
                        IsBodyHtml = false,

                        From = new MailAddress(contact.Email, contact.FullName)

                    };
                    email.To.Add(new MailAddress("AlhassanNageh@gmail.com", "WebsiteSUPPORTASU"));
                    email.Priority = System.Net.Mail.MailPriority.Normal;

                    SmtpClient mSmtpClient = new SmtpClient();
                    mSmtpClient.Send(email);

                    core.AddContactUs(contact.FullName, contact.Email, contact.Subject, contact.Message);
                }
                catch
                {
                    return View(contact);
                }

                return View("Thanks", contact);

            }
        


        ///****** Contact US ******/

        //[Authorize(Users = "Admin")]
        //public ActionResult DeleteContact()
        //{
        //    ViewBag.ElementsNames = objAdmin.ContactUsCore.GetContacts().ToList();
        //    return View("SelectDelete");
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, ContactUS contact)
        //{
        //    WebsiteSUPPORTASUCore.ContactUsService EditContact = new WebsiteSUPPORTASUCore.ContactUsService();
        //    EditContact.Ed(contact.Name, contact.Email, contact.Subject, contact.Message);
        //    return View("Updated");
        //}

        //[HttpPost]
        //public ActionResult DeleteContact(FormCollection form)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        int id = int.Parse(form["Elements"]);
        //        objAdmin.ContactUsCore.DeleteContact(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("DeleteContact");
        //    }
        //}

    }
}
