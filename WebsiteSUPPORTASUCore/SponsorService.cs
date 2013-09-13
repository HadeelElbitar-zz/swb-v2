

namespace WebsiteSUPPORTASUCore
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteSUPPORTASUDomain;
using System.Data.Entity;

using Sponsor = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Sponsor>;
using View = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.SponsorView>;
    public class SponsorService 
    {
        WebsiteSUPPORTASUDomain.websitedbEntities Model;

        public SponsorService()
        {
             Model = new WebsiteSUPPORTASUDomain.websitedbEntities();
             
        }
 
        //Test Method --> Worked
        public Sponsor GetSponsors()
        {      
            return Model.GETSponsors();
        }

        //Add New Sponsor
        public void AddSponsor( string Name, string Website, string Email, string Mobile, string Comments)
        {
            Model.AddSponsor(Name, Website, Email, Mobile, Comments);
        }

        // Edit Sponsers 
        public void EditSponsor(int id, string Name, string Website, string Email, string Mobile, string Comments)
        {
           Model.EditSponsor(id,Name,Website,Email,Mobile,Comments);

        }
        
        //delete Specific Sponsor
        public void DeleteSponsor(int id)
        {
            Model.Deletesponsor( id );
        }


        public Sponsor GetSponsor(int ID)
        {
            return Model.GETSponsor(ID);
        }

        public Sponsor GetEventSponsors(string type, int eventID)
        {
            return Model.GETSponsors();
        }
    }
}
