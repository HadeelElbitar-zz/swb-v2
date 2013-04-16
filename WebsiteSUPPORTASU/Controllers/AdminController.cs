
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
        
        /**********  StaticPage ************/
        //
        // GET: /AboutUs/Add
        [Authorize(Users="admin")]
        public ActionResult AddStaticPage()
        {
            return View();
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
                return RedirectToAction("EditStaticPage");
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
            return View("SelectDelete");
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

        /*************  Events  *****************/

        // GET: /Events/Add
        
        [Authorize(Users = "Admin")]
        public ActionResult AddEvent()
        {
            return View();
        }

        //
        // POST: /Events/Add

        [HttpPost]
        public ActionResult AddEvent(EventModel eEvent)
        {
            if (ModelState.IsValid)
            {
                objAdmin.EventsCore.AddEvent(eEvent.Name, eEvent.StartDate, eEvent.EndDate, eEvent.FullDescription, eEvent.ShortDescrption, eEvent.Comments);
                return RedirectToAction("AddEvent");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Events/Edit/5
        [Authorize(Users = "Admin")]
        public ActionResult EditEvent()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        public ActionResult EditEvent(EventModel Event, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Event.ID;
                objAdmin.EventsCore.EditEvent(ID, Event.Name, Event.StartDate, Event.EndDate, Event.FullDescription, Event.ShortDescrption, Event.Comments);
                return RedirectToAction("EditEvent");
            }
            else
            {
                 int ID = int.Parse(form["Elements"]);
                    Event eEvent = objAdmin.EventsCore.GetEvent(ID).FirstOrDefault();
                    Event.ID = ID;
                    Event.Name = eEvent.Name;
                    Event.StartDate = eEvent.StartDate;
                    Event.EndDate = eEvent.EndDate;
                    Event.FullDescription = eEvent.Description;
                    Event.ShortDescrption = eEvent.ShortDescription;
                    Event.Comments = eEvent.Comments;
                return View("EditEvent", Event);
            }
        }

        //
        // GET: /Events/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult DeleteEvent()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /Events/Delete/5

        [HttpPost]
        public ActionResult DeleteEvent(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.EventsCore.DeleteEvent(id);
                return RedirectToAction("DeleteEvent");
            }
            catch
            {
                return View("SelectDelete");
            }
        }

        /**********   Gallery  **************/

        //
        // GET: /Gallery/Add
        
        [Authorize(Users = "Admin")]
        public ActionResult AddGallery()
        {
            ViewBag.ElementsNames = objAdmin.EventsCore.GetEventsNames().ToList();
            return View();
        }

        //
        // POST: /Gallery/Add

        [HttpPost]
        public ActionResult AddGallery(GalleryModel gallery)
        {
            try
            {
                objAdmin.GalleryCore.createGallery(gallery.eventID, gallery.name, gallery.type, gallery.location, gallery.comments);
                // TODO: Add insert logic here

                return RedirectToAction("AddGallery");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Gallery/Edit/5
        
        [Authorize(Users = "Admin")]
        public ActionResult EditGallery()
        {
            ViewBag.ElementsNames = objAdmin.GalleryCore.getGalleryNames().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /Gallery/Edit/5

        [HttpPost]
        public ActionResult EditGallery(GalleryModel Gallery, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Gallery.ID;
                objAdmin.GalleryCore.editGallery(Gallery.eventID, Gallery.ID, Gallery.name, Gallery.type, Gallery.location, Gallery.comments);
                return RedirectToAction("EditGallery");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                    Gallery eGallery = objAdmin.GalleryCore.getGallery(ID).FirstOrDefault();
                    Gallery.ID = ID;
                    Gallery.name = eGallery.Name;
                    Gallery.type = eGallery.Type;
                    Gallery.eventID = eGallery.EventID;
                    Gallery.comments = eGallery.Comments;
                    Gallery.location = eGallery.Location;
                return View("EditGallery", Gallery);
            }
        }

        //
        // GET: /Gallery/Delete/5
        
        [Authorize(Users = "Admin")]
        public ActionResult DeleteGallery()
        {
            ViewBag.ElementsNames = objAdmin.GalleryCore.getGalleryNames().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /Gallery/Delete/5

        [HttpPost]
        public ActionResult DeleteGallery(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.GalleryCore.deleteGallery(id);
                return RedirectToAction("DeleteGallery");
            }
            catch
            {
                return View();
            }
        }

        /******** Sponsors *********/

        //
        // GET: /Sponser/Add
        
        [Authorize(Users = "Admin")]
        public ActionResult AddSponsor()
        {
            //Get The Default View For Making Addition (text box .. etc);
            return View();
        }

        //
        // POST: /Sponser/Add

        [HttpPost]
        public ActionResult AddSponsor(SponsorModel Sponsor)
        {
            try
            {
                // TODO: Add insert logic here
                objAdmin.SponsorCore.AddSponsor(Sponsor.Name, Sponsor.Website, Sponsor.Email, Sponsor.Mobile, Sponsor.Type);
                return RedirectToAction("AddSponsor");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sponser/Edit/5
        // Edit My Database (Access For Members Only) 
        [Authorize(Users = "Admin")]
        public ActionResult EditSponsor()
        {
            ViewBag.ElementsNames = objAdmin.SponsorCore.GetSponsors().ToList();
            return View("SelectEdit");
        }

        //
        // POST: /Sponser/Edit/5

        [HttpPost]
        public ActionResult EditSponsor(SponsorModel Sponsor, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Sponsor.ID;
                objAdmin.SponsorCore.EditSponsor(ID, Sponsor.Name, Sponsor.Website, Sponsor.Email, Sponsor.Mobile, Sponsor.Type);
                return RedirectToAction("EditSponsor");
            }
            else
            {
                int ID = int.Parse(form["Elements"]);
                Sponsor eSponsor = objAdmin.SponsorCore.GetSponsor(ID).FirstOrDefault();
                Sponsor.ID = ID;
                Sponsor.Name = eSponsor.Name;
                Sponsor.Website = eSponsor.Website;
                Sponsor.Email = eSponsor.Email;
                Sponsor.Mobile = eSponsor.ContactNumber;
                Sponsor.Type = eSponsor.Comments;
                return View("EditSponsor", Sponsor);
            }
        }

        //
        // GET: /Sponser/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult DeleteSponsor()
        {
            ViewBag.ElementsNames = objAdmin.SponsorCore.GetSponsors().ToList();
            return View("SelectDelete");
        }

        //
        // POST: /Sponser/Delete/5

        [HttpPost]
        public ActionResult DeleteSponsor(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.SponsorCore.DeleteSponsor(id);
                return RedirectToAction("DeleteSponsor");
            }
            catch
            {
                return View();
            }
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

        /******* Member *******/

        //
        // GET: /Member/Add
        
        [Authorize(Users = "Admin")]
        public ActionResult AddMember()
        {
            @ViewBag.Position = objAdmin.GetPositions().ToList();
            @ViewBag.College = objAdmin.GetColleges().ToList();
            @ViewBag.University = objAdmin.GetUniversities().ToList();
            @ViewBag.Committee = objAdmin.GetCommittees().ToList();
            return View();
        }

        //
        // POST: /Member/Add

        [HttpPost]
        public ActionResult AddMember(MemberModel member, FormCollection form)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
                member.CollegeID = int.Parse(form["College"]);
                member.UniversityID = int.Parse(form["University"]);
                member.PositionID = int.Parse(form["Position"]);
                member.CommitteeID = int.Parse(form["Committee"]);

                objAdmin.SupportiansCore.insert(member.FullName, member.Mobile, member.HomePhone, member.Email, member.CommitteeID, member.CollegeID, member.UniversityID, member.PositionID, member.state, member.Address, member.HireYear, member.Birthdate, member.ProfilePicture, member.Comments);
                return RedirectToAction("AddMember");
            }
            else
            {
                @ViewBag.Position = objAdmin.GetPositions().ToList();
                @ViewBag.College = objAdmin.GetColleges().ToList();
                @ViewBag.University = objAdmin.GetUniversities().ToList();
                @ViewBag.Committee = objAdmin.GetCommittees().ToList();
                return View();
            }
        }

        //
        // GET: /AboutUs/Edit/5
        
        [Authorize(Users = "Admin")]
        public ActionResult EditMember()
        {
            ViewBag.ElementsNames = objAdmin.SupportiansCore.GetMembersNames().ToList();
            return View("SelectEditMember");
        }

        //
        // POST: /AboutUs/Edit/5

        [HttpPost]
        public ActionResult EditMember(MemberModel Member, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int ID = Member.ID;
                Member.CollegeID = int.Parse(form["OldCollege"]);
                Member.UniversityID = int.Parse(form["OldUniversity"]);
                Member.PositionID = int.Parse(form["OldPosition"]);
                Member.CommitteeID = int.Parse(form["OldCommittee"]);

                objAdmin.SupportiansCore.edit(ID, Member.FullName, Member.Mobile, Member.HomePhone, Member.Email, Member.CommitteeID, Member.CollegeID, Member.UniversityID, Member.PositionID, Member.state, Member.Address, Member.HireYear, Member.Birthdate, Member.ProfilePicture, Member.Comments);
        
                return RedirectToAction("EditMember");
            }
            else
            {
                @ViewBag.Positions = objAdmin.GetPositions().ToList();
                @ViewBag.Colleges = objAdmin.GetColleges().ToList();
                @ViewBag.Universities = objAdmin.GetUniversities().ToList();
                @ViewBag.Committees = objAdmin.GetCommittees().ToList();

                int ID = int.Parse(form["Elements"]);
                Member eMember = objAdmin.SupportiansCore.GetMember(ID).FirstOrDefault();
                Member.ID = ID;
                Member.FullName = eMember.FullName; Member.Mobile = eMember.Mobile; Member.HomePhone = eMember.HomePhone; Member.Email = eMember.Email; ViewBag.Committee = Member.CommitteeID; ViewBag.Committee = Member.CollegeID; ViewBag.Committee = Member.UniversityID; ViewBag.Committee = Member.PositionID; Member.state = eMember.state; Member.Address = eMember.Address; Member.HireYear = eMember.HireYear; Member.Birthdate = eMember.Birthdate; Member.ProfilePicture = eMember.ProfilePicture; Member.Comments = eMember.Comments;
                return View("EditMember", Member);
            }
        }

        //
        // GET: /AboutUs/Delete/5
        
        [Authorize(Users = "Admin")]
        public ActionResult DeleteMember()
        {
            ViewBag.ElementsNames = objAdmin.SupportiansCore.GetMembersNames().ToList();
            return View("SelectDeleteMember");
        }

        //
        // POST: /AboutUs/Delete/5

        [HttpPost]
        public ActionResult DeleteMember(FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                int id = int.Parse(form["Elements"]);
                objAdmin.SupportiansCore.DeleteMember(id);
                return RedirectToAction("DeleteMember");
            }
            catch
            {
                return RedirectToAction("DeleteMember");
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


    }
}
