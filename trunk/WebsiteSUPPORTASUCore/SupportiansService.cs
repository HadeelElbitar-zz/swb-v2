

namespace WebsiteSUPPORTASUCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebsiteSUPPORTASUDomain;
    using System.Data.Entity;

    using MembersNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.MembersName>;
    using eMember = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Member>;
    using eCommittee = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Committee>;


    public class SupportiansService
    {
        WebsiteSUPPORTASUDomain.websitedbEntities obj;

        public SupportiansService()
        {
            obj = new WebsiteSUPPORTASUDomain.websitedbEntities();
        }

        public void insert(string FullName, string Mobile, string HomePhone, string Email, int CommitteeID, int CollegeID, int UniversityID, int PositionID, string state, string Address, DateTime HireYear, DateTime Birthdate, string ProfilePicture, string Comments)
        {
            obj.AddMember(FullName, Mobile, HomePhone, Email, CommitteeID, CollegeID, UniversityID, PositionID, state, Address, HireYear, Birthdate, ProfilePicture, Comments);

        }


        public void edit(int ID, string FullName, string Mobile, string HomePhone, string Email, int CommitteeID, int CollegeID, int UniversityID, int PositionID, string state, string Address, DateTime HireYear, DateTime Birthdate, string ProfilePicture, string Comments)
        {
            obj.EditMember(ID, FullName, Mobile, HomePhone, Email, CommitteeID, CollegeID, UniversityID, PositionID, state, Address, HireYear, Birthdate, ProfilePicture, Comments);
        }

        public eMember GetMember(String Mobile)
        {
            return obj.ViewMember(Mobile);
        }

        public List<ViewMembers> GetAllMembers()
        {
            return obj.ViewMembers().ToList();
        }

        public List<ViewMembers> ViewAllMembersOrderedByCommitte()
        {
            return GetAllMembers().OrderBy(x => x.CommitteName).ToList();
        }

        public List<Committee> GetAllCommitties()
        {
            //    List<Committee> c = obj.Committees.ToList();
            //    return c;
            List<Committee> g = obj.GetCommittees().ToList();

            return g;

        }

        public MembersNames GetMembersNames()
        {
            return obj.GetMembersNames();
        }

        public eMember GetMember(int ID)
        {
            return obj.GetMember(ID);
        }

        public void DeleteMember(int id)
        {
            obj.DeleteMember(id);
        }
    }
}
