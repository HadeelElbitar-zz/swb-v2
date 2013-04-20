
namespace WebsiteSUPPORTASUCore
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteSUPPORTASUDomain;
using System.Data.Entity;

using StaticPage = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.StaticPage>;


    public class StaticPageService
    {
        private WebsiteSUPPORTASUDomain.websitedbEntities model;
        
        public StaticPageService()
        {
            model = new websitedbEntities();
        }
        
        public void AddStaticPage(string name, string text)
        {
            model.AddStaticPage(name, text);
            
        }

        public void DeleteStaticPage(int id)
        {
            model.DeleteStaticPage(id);
        
         }

        public void EditStaticPage(int id, string name, string text)
        {
            model.EditStaticPage(id, name, text);
         
        }

        public StaticPage GetStaticPage(string Name)
        {
            return model.GetStaticPage(Name);
        }

        public StaticPage GetStaticPages()
        {
            return model.GetStaticPages();
        }

        public StaticPage GetStaticPageByID(int ID)
        {
            return model.GetStaticPageByID(ID);
        }
    }
}
