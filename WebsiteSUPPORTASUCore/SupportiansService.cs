

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
            obj.EditMember(ID ,FullName, Mobile, HomePhone, Email, CommitteeID, CollegeID, UniversityID, PositionID, state, Address, HireYear, Birthdate, ProfilePicture, Comments);
        }

        public eMember ViewMember(String Mobile)
        {
            return obj.ViewMember(Mobile);
        }

        public eMember ViewAllMembers()
        {
            return obj.ViewMembers();
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
