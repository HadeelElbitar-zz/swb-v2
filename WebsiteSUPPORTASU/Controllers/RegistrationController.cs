
namespace WebsiteSUPPORTASU.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

    public class RegistrationController : Controller
    {

        WebsiteSUPPORTASUCore.ParticipantService Core;
        WebsiteSUPPORTASUCore.AdminService AdminCore;
        WebsiteSUPPORTASUCore.SupportiansService MemberCore;

        public RegistrationController()
        {
            Core = new WebsiteSUPPORTASUCore.ParticipantService();
            AdminCore = new WebsiteSUPPORTASUCore.AdminService();
            MemberCore = new WebsiteSUPPORTASUCore.SupportiansService();
        }

        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return RedirectToAction("Online");
        }

        public ActionResult DroopOffLogOn()
        {
            return View("UserLogOn");
        }

        [HttpPost]
        public ActionResult DroopOffLogOn(UserLogOn user)
        {
            if (ModelState.IsValid)
            {
                if (Core.UniqueParticipant(user.Email) == user.Email && Core.UniqueParticipant(user.Barcode) == user.Barcode && Core.GetLogedOn(user.Barcode) != false)
                {
                    Core.SetLogOn(user.Barcode, false);

                    HRDroopOff participant = new HRDroopOff();
                    
                    WebsiteSUPPORTASUDomain.Participant Participant = Core.GetParticipant(user.Barcode);
                    participant.PaticipantName = Participant.FullName;
                    participant.PaticipantEmail = Participant.Email;
                    participant.PaticipantBarcode = Participant.Barcode;
                    return View("FillForm", participant);
                }
                else
                {
                    ViewBag.ERROR = "No Such this Account Registered with Us";
                    return View("UserLogOn", user);
                }
            }
            else
            {
                return View("UserLogOn", user);
            }
        }

        public ActionResult FillForm()
        {
            return RedirectToAction("DroopOffLogOn");
        }

        [HttpPost]
        public ActionResult FillForm(HRDroopOff user)
        {
            String Barcode = Core.FirstFormFill(user.PaticipantBarcode);
            if (Barcode ==  user.PaticipantBarcode)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                string Form = "PaticipantName: " + user.PaticipantName + "\n";
                Form += "PaticipantEmail: " + user.PaticipantEmail + "\n";
                Form += "PaticipantBarcode: " + user.PaticipantBarcode + "\n";
                Form += "knowSupport: " + user.knowSupport + "\n";
                Form += "HearedAbout: " + user.HearedAbout + "\n";
                Form += "InterestedIn: " + user.InterestedIn + "\n";
                Form += "Expectations: " + user.Expectations + "\n";
                Form += "Leave: " + user.Leave + "\n";

                Core.AddHRComment(user.PaticipantBarcode, Form);

                return View("../Shared/Thanks");
            }
            else
            {
                return View("FillForm", user);
            }
        }

        public ActionResult Online()
        {

            @ViewBag.Colleges = AdminCore.GetColleges().ToList();
            @ViewBag.Universities = AdminCore.GetUniversities().ToList();
            return View("Registration");
        }
        //
        // POST: /Registration/Create

        [HttpPost]
        public ActionResult Online(ParticipantModel Participant ,FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                string x = Core.UniqueParticipant(Participant.Mobile);
                string y = Core.UniqueParticipant(Participant.Email);
                if (x == Participant.Mobile || y == Participant.Email)
                {
                    @ViewBag.Colleges = AdminCore.GetColleges().ToList();
                    @ViewBag.Universities = AdminCore.GetUniversities().ToList();
                    @ViewBag.ERROR = "This Mobile or Email Already in Database";
                    return View("Registration", Participant);
                }
                else
                {
                    @ViewBag.Barcode = Core.AddParticpant(Participant.FullName, Participant.Mobile, Participant.Email, Participant.HomePhone, Participant.College, Participant.University, Participant.Workshop, Participant.Interview, 11, "A", Participant.Comments, 2);


                    return View("../Shared/Thanks");
                }
            }
            else
            {
                @ViewBag.Colleges = AdminCore.GetColleges().ToList();
                @ViewBag.Universities = AdminCore.GetUniversities().ToList();
                return View("Registration", Participant);
            }
        }

        [Authorize(Users = "admin, EveryOne")]
        public ActionResult Booth()
        {
            @ViewBag.Colleges = AdminCore.GetColleges().ToList();
            @ViewBag.Universities = AdminCore.GetUniversities().ToList();
            @ViewBag.Members = MemberCore.GetMembersNames().ToList();
            return View("Registration");
        }
        //
        // POST: /Registration/Create

        [HttpPost]
        public ActionResult Booth(ParticipantModel Participant, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                string x = Core.UniqueParticipant(Participant.Mobile);
                string y = Core.UniqueParticipant(Participant.Email);
                if (x == Participant.Mobile || y == Participant.Email)
                {
                    @ViewBag.Colleges = AdminCore.GetColleges().ToList();
                    @ViewBag.Universities = AdminCore.GetUniversities().ToList();
                    @ViewBag.Members = MemberCore.GetMembersNames().ToList();
                    @ViewBag.ERROR = "This Mobile or Email Already in Database";
                    return View("Registration", Participant);
                }
                else
                {
                    @ViewBag.Barcode = Core.AddParticpant(Participant.FullName, Participant.Mobile, Participant.Email, Participant.HomePhone, Participant.College, Participant.University, Participant.Workshop, Participant.Interview, Participant.EventID, "B", Participant.Comments, Participant.Member);


                    return View("../Shared/Thanks");
                }
            }
            else
            {
                @ViewBag.Colleges = AdminCore.GetColleges().ToList();
                @ViewBag.Universities = AdminCore.GetUniversities().ToList();
                @ViewBag.Members = MemberCore.GetMembersNames().ToList();
                return View("Registration", Participant);
            }
        }
        

        //
        // GET: /Registration/Edit/5


        [Authorize(Users = "admin, EveryOne")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Registration/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Registration/Delete/5


        [Authorize(Users = "admin, EveryOne")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Registration/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Users = "admin")]
        public string SendBlock()
        {
            int x = 0;
            string Data = "";
            DateTime d = new DateTime(2013, 4, 12);
            try
            {
                List<WebsiteSUPPORTASUDomain.Participant> Participants = Core.GetParticipants();
                foreach (var p in Participants)
                {
                    x++;
                    if(p.HRComments != null || p.timestamp.Date.Equals(d)){
                        Data += p.FullName + ", ";
                        Data += p.Mobile + ", ";
                        Data += p.Email + "<br/><br/>";
                        //AdminCore.ParticipantCore.SendEMail(p.FullName, p.Email);
                    }
                }
                return "Done" + x.ToString() + Data;
            }
            catch (Exception e)
            {
                return "Not Done" + x.ToString() + e.Message + Data;
            }
        }

        [Authorize(Users = "admin")]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string Barcode)
        {
            WebsiteSUPPORTASUDomain.Participant p = Core.GetParticipant(Barcode);
                try
                {
                    string Body = "Dear: " + p.FullName + "<br/><br/>" +
        "Congratulations! We are pleased to accept you to join “Droop Off” conference.<br/>"
        + "The conference will be tomorrow from 10:00 am to 6:00 pm in Palestine hall at The Faculty of Engineering, Ain Shams University<br/><br/>"
        + "<h2>Waiting for you tomorrow</h2><br/><br/>" +
        "<br/>If you have any further questions (queries) or comments, please feel free (don't hesitate) to contact us anytime on any of the following links:<br/>" +
        "Our Website: www.support-asu.org <br/>" +
        "Our Facebook page: https://www.facebook.com/SUPPORT.FCIS <br/>" +
        "Our Twitter account: https://twitter.com/#!/SupportASU    <br/>" +
        "<br/><br/>Yours sincerely,<br/>" +
        "<br/>HR-TEAM<br/>" +
        "SUPPORT’13 “Droop Off Conference<br/>";

                    AdminCore.ParticipantCore.SendEMail(Body, p.Email);
                    ModelState.AddModelError("Barcode", "Done");
                    return View();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Barcode", e.Message);
                    return View();
                }
        }

        [Authorize(Users = "admin")]
        public string SendEmailDroopOff()
        {
            int x = 0;
            try
            {
                List<WebsiteSUPPORTASUDomain.Participant> participants = Core.GetHRCommentsSeen().ToList();
                foreach (var p in participants)
                {
                    string Body = "Dear: " + p.FullName + "<br/><br/>" +
        "Congratulations! We are pleased to accept you to join “Droop Off” conference.<br/>"
        + "The conference will be tomorrow from 10:00 am to 6:00 pm in Palestine hall at The Faculty of Engineering, Ain Shams University<br/><br/>"
        + "<h2>Waiting for you tomorrow</h2><br/><br/>" +
        "<br/>If you have any further questions (queries) or comments, please feel free (don't hesitate) to contact us anytime on any of the following links:<br/>" +
        "Our Website: www.support-asu.org <br/>" +
        "Our Facebook page: https://www.facebook.com/SUPPORT.FCIS <br/>" +
        "Our Twitter account: https://twitter.com/#!/SupportASU    <br/>" +
        "<br/><br/>Yours sincerely,<br/>" +
        "<br/>HR-TEAM<br/>" +
        "SUPPORT’13 “Droop Off Conference<br/>";

                    AdminCore.ParticipantCore.SendEMail(Body, p.Email);
                    x++;
                }
                return "Done" + x.ToString();
            }
            catch (Exception e)
            {
                return e.Message + x.ToString() ;
            }
        }

        public ActionResult AddBlock()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlock(FormCollection form)
        {
            try
            {
                char[] split = { '\n', '\r' };
                string Block = form["Block"];
                string[] Content = Block.Split(split);
                string[] participant;
                foreach (string z in Content)
                {
                    if (z != "")
                    {
                        participant = z.Split(',');
                        Core.AddParticpant(participant[0], participant[2].Trim(), participant[1], "", 17, 6, 0, 0, 11, "B", "", 2);
                    }
                }
                @ViewBag.Message = "Done";
                return View();
            }
            catch(Exception e)
            {
                @ViewBag.Message = e.Message;
                return View();
            }
        }
    }
}