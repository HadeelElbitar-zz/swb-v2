
namespace WebsiteSUPPORTASU.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebsiteSUPPORTASU.Models;
    using System.Web.Routing;
    using System.Web.Security;
    using WebsiteSUPPORTASUDomain;

    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;
    using Event = WebsiteSUPPORTASUDomain.Event;
    using eEvent = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Event>;
    using eSponsor = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Sponsor>;
    using University = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.University>;
    using eCollege = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.College>;
    using eUniversity = WebsiteSUPPORTASUDomain.University;
    
    [ValidateInput(false)]
    public class AdminController : Controller
    {
        WebsiteSUPPORTASUCore.AdminService objAdmin;
        
        public AdminController()
        {
            objAdmin = new WebsiteSUPPORTASUCore.AdminService();
        }

        [Authorize(Users = "admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(FormCollection form, ParticipantsEmailsModel p)
        {
            char[] ss = {','};
            string res = "";
            p.Emails = form["emails"].Split(ss); 
            foreach (var email in p.Emails)
            {
                res += objAdmin.SendBlockEmails(email, p.Subject, p.body);
                res += "\n";
            }
            ModelState.AddModelError("", res);
            return View();
        }

        /********** HR Area **********/

        [Authorize(Users = "admin, AdminHR")]
        public ActionResult AdminHR()
        {
            return View();
        }

        [Authorize(Users = "admin, AdminHR")]
        public ActionResult DroopOff()
        {
            return View();
        }

        [Authorize(Users = "admin, AdminHR")]
        public ActionResult DroopOffSeen()
        {
            ViewBag.Participants = objAdmin.ParticipantCore.GetHRCommentsSeen().ToList();
            return View("DroopOffSelect");
        }

        [HttpPost]
        public ActionResult DroopOffSeen(FormCollection Participant)
        {
            Participant participant = objAdmin.ParticipantCore.GetParticipant(Participant["Participant"]);
            if (participant == null)
            {
                return RedirectToAction("DroopOffSeen");
            }
            else
            {
                HRDroopOff pp = new HRDroopOff(participant.HRComments); 
                return View(pp);
            }
        }

        [Authorize(Users = "admin, AdminHR")]
        public ActionResult DroopOffNotSeen()
        {
            ViewBag.Participants = objAdmin.ParticipantCore.GetHRComments().ToList();
            return View("DroopOffSelect");
        }
        
        [HttpPost]
        public ActionResult DroopOffNotSeen(FormCollection Participant)
        {
            Participant participant = objAdmin.ParticipantCore.GetParticipant(Participant["Participant"]);
            if (participant == null)
            {
                return RedirectToAction("DroopOffSeen");
            }
            else
            {
                HRDroopOff pp = new HRDroopOff(participant.HRComments);
                return View(pp);
            }
        }

        private string SplitBarcode(string x)
        {
            string barcode = "";
            string tmp = "PaticipantBarcode: ";
            bool b;
            for (int i = 0; i < x.Count(); ++i )
            {
                if (x[i] == 'P')
                {
                    b = true;
                    for (int j = 0; j < tmp.Count(); ++j)
                    {
                        if (x[i + j] != tmp[j])
                        {
                            b = false;
                            i += j-1;
                            break;
                        }
                    }
                    if (b)
                    {
                        for (int j = i + tmp.Count(); ; ++j)
                        {
                            if (!b)
                            {
                                if (x[j] > '9' || x[j] < '0')
                                    break;
                            }
                            barcode += x[j];
                            if (x[j] == '-')
                                b = false;
                        }
                    }
                }
            }
            return barcode;
        }

        [HttpPost]
        public ActionResult AddDroopOffComments(HRDroopOff user)
        {
            if (user.Result == null) user.Result = user.OldResult;
            string Form ="";
            if (user.Result != null)
            {
                Form = "Result: " + user.Result + "\n";
            }
            Form += user.knowSupport + "\n";
            string Barcode = SplitBarcode(user.knowSupport);
            objAdmin.ParticipantCore.AddHRComment(Barcode, Form);

            return RedirectToAction("DroopOffNotSeen");
        }


        /************   Login  ************/
        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        /******** Basics ********/

        //
        // GET: /AboutUs/Add

        [Authorize(Users = "admin")]
        public ActionResult AddCommittee()
        {
            return View();
        }

        //
        // POST: /Committee/Add

        [HttpPost]
        public ActionResult AddCommittee(Models.CommitteeModel Committee)
        {
            if (ModelState.IsValid)
            {
                objAdmin.AddCommittee(Committee.Name, Committee.Description);
                return RedirectToAction("AddCommittee");
            }
            else
            {
                return View(Committee);
            }


        }

        //
        // GET: /AboutUs/Edit/5
        
        [Authorize(Users = "Admin")]
        public ActionResult EditCommittee()
        {
            ViewBag.ElementsNames = objAdmin.GetCommittees().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /AboutUs/Edit/5

        [HttpPost]
        public ActionResult EditCommittee(CommitteeModel Committee, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Committee.ID;
                objAdmin.EditCommittee(ID, Committee.Name, Committee.Description);
                return RedirectToAction("EditCommittee");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                Committee eCommittee = objAdmin.GetCommittee(ID).FirstOrDefault();
                Committee.ID = ID;
                Committee.Name = eCommittee.Name;
                Committee.Description = eCommittee.Description;
                return View("EditCommittee", Committee);
            }
        }

        //
        // GET: /AboutUs/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult DeleteCommittee()
        {
            ViewBag.ElementsNames = objAdmin.GetCommittees().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /AboutUs/Delete/5

        [HttpPost]
        public ActionResult DeleteCommittee(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.DeleteCommittee(id);
                return RedirectToAction("DeleteCommittee");
            }
            catch
            {
                return RedirectToAction("DeleteCommittee");
            }

        }

        //
        // GET: /AboutUs/Add
        
        [Authorize(Users = "admin")]
        public ActionResult AddCollege()
        {
            ViewBag.University = objAdmin.GetUniversities().ToList();
            return View();
        }

        //
        // POST: /College/Add

        [HttpPost]
        public ActionResult AddCollege(Models.CollegeModel College)
        {
            if (ModelState.IsValid)
            {
                objAdmin.AddCollege(College.Name, College.Location, College.Comments);
                return RedirectToAction("AddCollege");
            }
            else
            {
                return View(College);
            }


        }

        //
        // GET: /AboutUs/Edit/5
        
        [Authorize(Users = "Admin")]
        public ActionResult EditCollege()
        {
            ViewBag.ElementsNames = objAdmin.GetColleges().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /AboutUs/Edit/5

        [HttpPost]
        public ActionResult EditCollege(CollegeModel College, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = College.ID;
                objAdmin.EditCollege(ID, College.Name, College.Location, College.Comments);
                return RedirectToAction("EditCollege");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                College eCollege = objAdmin.GetCollege(ID).FirstOrDefault();
                College.ID = ID;
                College.Name = eCollege.Name;
                College.Location = eCollege.Location;
                College.Comments  = eCollege.Comments;
                return View("EditCollege", College);
            }
        }

        //
        // GET: /AboutUs/Delete/5
        
        [Authorize(Users = "Admin")]
        public ActionResult DeleteCollege()
        {
            ViewBag.ElementsNames = objAdmin.GetColleges().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /AboutUs/Delete/5

        [HttpPost]
        public ActionResult DeleteCollege(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.DeleteCollege(id);
                return RedirectToAction("DeleteCollege");
            }
            catch
            {
                return RedirectToAction("DeleteCollege");
            }

        }

        //
        // GET: /AboutUs/Add
        
        [Authorize(Users = "admin")]
        public ActionResult AddUniversity()
        {
            return View();
        }

        //
        // POST: /University/Add

        [HttpPost]
        public ActionResult AddUniversity(Models.UniversityModel University)
        {
            if (ModelState.IsValid)
            {
                objAdmin.AddUniversity(University.Name, University.Location);
                return RedirectToAction("AddUniversity");
            }
            else
            {
                return View(University);
            }


        }

        //
        // GET: /AboutUs/Edit/5
        [Authorize(Users = "Admin")]
        
        public ActionResult EditUniversity()
        {
            ViewBag.ElementsNames = objAdmin.GetUniversities().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /AboutUs/Edit/5

        [HttpPost]
        public ActionResult EditUniversity(UniversityModel University, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = University.ID;
                objAdmin.EditUniversity(ID, University.Name, University.Location);
                return RedirectToAction("EditUniversity");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                eUniversity eUniversity = objAdmin.GetUniversity(ID).FirstOrDefault();
                University.ID = ID;
                University.Name = eUniversity.Name;
                University.Location = eUniversity.Location;
                return View("EditUniversity", University);
            }
        }

        //
        // GET: /AboutUs/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult DeleteUniversity()
        {
            ViewBag.ElementsNames = objAdmin.GetUniversities().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /AboutUs/Delete/5

        [HttpPost]
        public ActionResult DeleteUniversity(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.DeleteUniversity(id);
                return RedirectToAction("DeleteUniversity");
            }
            catch
            {
                return RedirectToAction("DeleteUniversity");
            }

        }

        //
        // GET: /AboutUs/Add
        
        [Authorize(Users = "admin")]
        public ActionResult AddPosition()
        {
            return View();
        }

        //
        // POST: /Position/Add

        [HttpPost]
        public ActionResult AddPosition(PositionModel Position)
        {
            if (ModelState.IsValid)
            {
                objAdmin.AddPosition(Position.Name, Position.Comment);
                return RedirectToAction("AddPosition");
            }
            else
            {
                return View(Position);
            }


        }

        //
        // GET: /AboutUs/Edit/5
        
        [Authorize(Users = "Admin")]
        public ActionResult EditPosition()
        {
            ViewBag.ElementsNames = objAdmin.GetPositions().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /AboutUs/Edit/5

        [HttpPost]
        public ActionResult EditPosition(PositionModel Position, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Position.ID;
                objAdmin.EditPosition(ID, Position.Name, Position.Comment);
                return RedirectToAction("EditPosition");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                Position ePosition = objAdmin.GetPosition(ID).FirstOrDefault();
                Position.ID = ID;
                Position.Name = ePosition.Name;
                Position.Comment = ePosition.Comments;
                return View("EditPosition", Position);
            }
        }

        //
        // GET: /AboutUs/Delete/5
        
        [Authorize(Users = "Admin")]
        public ActionResult DeletePosition()
        {
            ViewBag.ElementsNames = objAdmin.GetPositions().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /AboutUs/Delete/5

        [HttpPost]
        public ActionResult DeletePosition(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.DeletePosition(id);
                return RedirectToAction("DeletePosition");
            }
            catch
            {
                return RedirectToAction("DeletePosition");
            }

        }


        /**********  Tags ************/
        
        //
        // GET: /AboutUs/Add

        [Authorize(Users = "admin")]
        public ActionResult EventTagUniversity()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEvents().OrderBy(X => X.StartDate.Year).Reverse().ToList();;
            ViewBag.Universities = objAdmin.GetUniversities();
            return View("EventTagUniversity");
        }

        //
        // POST: /StaticPage/Add

        [HttpPost]
        public ActionResult EventTagUniversity(EventUniversityModel model, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = int.Parse(form["EventID"]);
                char[] split = { '\r', '\n' };
                string[] x = form["Universities"].Split(split);
                University Universities = objAdmin.GetUniversities();
                foreach (var university in Universities)
                {
                    for (int i = 0; i < x.Count(); ++i)
                        if (x[i] == university.Name)
                            objAdmin.AddEventTagUniversity(ID, university.ID);
                }
                return RedirectToAction("EventTagUniversity");
            }
            else
            {
                return View("EventTagUniversity", model);
            }
        }
        
        [Authorize(Users = "admin")]
        public ActionResult EventTagSponsor()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEvents().OrderBy(X => X.StartDate.Year).Reverse().ToList();;
            ViewBag.Sponsors = objAdmin.SponsorCore.GetSponsors();
            return View("EventTagSponsor");
        }

        //
        // POST: /StaticPage/Add

        [HttpPost]
        public ActionResult EventTagSponsor(EventSponsorModel model, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = int.Parse(form["EventID"]);
                char[] split = { '\r', '\n' };
                string[] x = form["Sponsors"].Split(split);
                eSponsor Sponsors = objAdmin.SponsorCore.GetSponsors();
                foreach (var Sponsor in Sponsors)
                {
                    for (int i = 0; i < x.Count(); ++i)
                        if (x[i] == Sponsor.Name)
                            objAdmin.AddEventTagSponsor(ID, Sponsor.ID);
                }
                return RedirectToAction("EventTagSponsor");
            }
            else
            {
                return View("EventTagSponsor", model);
            }
        }

        [Authorize(Users = "admin")]
        public ActionResult UniversityTagCollege()
        {
            ViewBag.Universities = objAdmin.GetUniversities();
            ViewBag.Colleges = objAdmin.GetColleges();
            return View("UniversityTagCollege");
        }

        //
        // POST: /StaticPage/Add

        [HttpPost]
        public ActionResult UniversityTagCollege(UniversityCollegeModel model, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = int.Parse(form["UniversityID"]);
                char[] split = { '\r', '\n' };
                string[] x = form["Colleges"].Split(split);
                eCollege Colleges = objAdmin.GetColleges();
                foreach (var college in Colleges)
                {
                    for (int i = 0; i < x.Count(); ++i)
                        if (x[i] == college.Name)
                            objAdmin.AddUniversityCollege(ID, college.ID);
                }
                return RedirectToAction("UniversityTagCollege");
            }
            else
            {
                return View("UniversityTagCollege", model);
            }
        }

        /**********  StaticPage ************/
        //
        // GET: /AboutUs/Add
        [Authorize(Users = "admin")]
        public ActionResult AddStaticPage()
        {
            return View("../Admin/AddStaticPage");
        }

        //
        // POST: /StaticPage/Add

        [HttpPost]
        public ActionResult AddStaticPage(StaticPagesModel page)
        {
            if (ModelState.IsValid)
            {
                objAdmin.StaticPageCore.AddStaticPage(page.Name, page.Content);
                return RedirectToAction("AddStaticPage");
            }
            else
            {
                return View(page);
            }


        }

        //
        // GET: /AboutUs/Edit/5

        [Authorize(Users = "Admin")]
        public ActionResult EditStaticPage()
        {
            ViewBag.ElementsNames = objAdmin.StaticPageCore.GetStaticPages().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /AboutUs/Edit/5

        [HttpPost]
        public ActionResult EditStaticPage(StaticPagesModel Page, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Page.ID;
                objAdmin.StaticPageCore.EditStaticPage(ID, Page.Name, Page.Content);
                return RedirectToAction("EditStaticPage", "Admin");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                StaticPage ePage = objAdmin.StaticPageCore.GetStaticPageByID(ID).FirstOrDefault();
                Page.ID = ID;
                Page.Name = ePage.Name;
                Page.Content = ePage.Content;
                return View("EditStaticPage", Page);
            }
        }

        //
        // GET: /AboutUs/Delete/5

        [Authorize(Users = "Admin")]
        public ActionResult DeleteStaticPage()
        {
            ViewBag.ElementsNames = objAdmin.StaticPageCore.GetStaticPages().ToList();
            return View("../Admin/SelectDelete");
        }

        //
        // POST: /AboutUs/Delete/5

        [HttpPost]
        public ActionResult DeleteStaticPage(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.StaticPageCore.DeleteStaticPage(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DeleteStaticPage");
            }

        }

    }
}
