
namespace WebsiteSUPPORTASUCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebsiteSUPPORTASUDomain;
    using System.Data.Entity;

    public class CommitteService
    {
        websitedbEntities db = new websitedbEntities();

        public System.Data.Objects.ObjectResult<Committee> ViewAllCommitties()
        {
            return db.GetCommittees();
        }

        public void insert(string name, string description, string imageName)
        {
            // db.AddCommittee(name, description, imageName);
        }

        public void edit(int id, string name, string description, string imageName)
        {
            // db.EditCommittee(id, name, description, imageName);
        }

        public System.Data.Objects.ObjectResult<Committee> ViewCommitte(int id)
        {
            return db.GetCommittee(id);
        }

        public void delete(int id)
        {
            db.DeleteCommittee(id);
        }
    }
}
