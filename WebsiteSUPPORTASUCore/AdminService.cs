
namespace WebsiteSUPPORTASUCore
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Position = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Position>;
    using College = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.College>;
    using Committee = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Committee>;
    using University = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.University>;

    public class AdminService
    {

        public SupportiansService SupportiansCore;
        public ContactUsService ContactUsCore;
        public EventService EventsCore;
        public GalleryService GalleryCore;
        public SponsorService SponsorCore;
        public StaticPageService StaticPageCore;
        public ParticipantService ParticipantCore;
        
        private WebsiteSUPPORTASUDomain.websitedbEntities Model;

        public AdminService()
        {
            SupportiansCore = new SupportiansService();
            ContactUsCore = new ContactUsService();
            EventsCore = new EventService();
            GalleryCore = new GalleryService();
            SponsorCore = new SponsorService();
            StaticPageCore = new StaticPageService();
            ParticipantCore = new ParticipantService();
            Model = new WebsiteSUPPORTASUDomain.websitedbEntities();
        }

        public Position GetPositions()
        {
            return Model.GetPositions();
        }

        public Position GetPosition(int ID)
        {
            return Model.GetPosition(ID);
        }

        public void AddPosition(string Position, string comment = "")
        {
            Model.AddPosition(Position, comment);
        }

        public void DeletePosition(int ID)
        {
            Model.DeletePosition(ID);
        }

        public void EditPosition(int ID, string Position, string comment = "")
        {
            Model.EditPosition(ID, Position, comment);
        }

        public College GetColleges()
        {
            return Model.GetColleges();
        }

        public College GetCollege(int ID)
        {
            return Model.GetCollege(ID);
        }

        public void AddCollege(string College, string location = "", string comment = "")
        {
            Model.AddCollege(College, location, comment);
        }

        public void DeleteCollege(int ID)
        {
            Model.DeleteCollege(ID);
        }

        public void EditCollege(int ID, string College, string location = "", string comment = "")
        {
            Model.EditCollege(ID, College, location, comment);
        }

        public University GetUniversities()
        {
            return Model.GetUniversities();
        }

        public University GetUniversity(int ID)
        {
            return Model.GetUniversity(ID);
        }

        public void AddUniversity(string University, string location = "")
        {
            Model.AddUniversity(University, location);
        }

        public void DeleteUniversity(int ID)
        {
            Model.DeleteUniversity(ID);
        }

        public void EditUniversity(int ID, string University, string location = "")
        {
            Model.EditUniversity(ID, University, location);
        }

        public Committee GetCommittees()
        {
            return Model.GetCommittees();
        }

        public Committee GetCommittee(int ID)
        {
            return Model.GetCommittee(ID);
        }

        public void AddCommittee(string Committee, string location = "")
        {
            Model.AddCommittee(Committee, location);
        }

        public void DeleteCommittee(int ID)
        {
            Model.DeleteCommittee(ID);
        }

        public void EditCommittee(int ID, string Committee, string location = "")
        {
            Model.EditCommittee(ID, Committee, location);
        }

        public void AddEventTagUniversity(int ID, int UniversityID)
        {
            Model.AddEventUniversity(UniversityID, ID);
        }

        public void AddEventTagSponsor(int ID, int SponsorID)
        {
            Model.AddEventSponsor(SponsorID, ID);
        }

        public void AddUniversityCollege(int ID, int collegeID)
        {
            Model.AddUniversityCollege(ID, collegeID);
        }

        public void AddMemberEvent(int ID, int EventID)
        {
            Model.AddEventMember(ID, EventID);
        }
    }
}
