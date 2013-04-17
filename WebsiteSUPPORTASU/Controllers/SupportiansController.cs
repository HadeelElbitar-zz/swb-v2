

namespace WebsiteSUPPORTASU.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSUPPORTASU.Models;
    using WebsiteSUPPORTASUCore;
    using WebsiteSUPPORTASUDomain;

    public class SupportiansController : Controller
    {
        WebsiteSUPPORTASUCore.SupportiansService obj;
        AdminService objAdmin;
        
        public SupportiansController ()
        {
            obj = new WebsiteSUPPORTASUCore.SupportiansService();
            objAdmin = new AdminService();   
        }
        
        // GET: /Member/

        public ActionResult Index()
        {
            return View();
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
            if (ModelState.IsValid)
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


    }
}
