

namespace WebsiteSUPPORTASUCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebsiteSUPPORTASUDomain;
    using System.Data.Entity;

    using Gallery = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Gallery>;
    using GalleryNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.GalleryName>;

    public class GalleryService
    {
        WebsiteSUPPORTASUDomain.websitedbEntities model;
       
        public GalleryService()
        {
            model = new websitedbEntities();
            
        }
        
        public Gallery getEventGallery(int eventID, string Type)
        {
            return model.getEventGallery(eventID, Type);
        }

        public Gallery getPageGallery(string PageName, string Type)
        {
            try
            {
                return model.getPageGallery(PageName, Type);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Gallery getGallery(int ID)
        {
            return model.getGallery(ID);
        }

        public void createGallery(int eventID, string name, string type, string location, string comments)
       {
            model.AddGallery(eventID, name, type, location, comments);    
       }

        public void editGallery(int eventID, int galleryID, string name, string type, string location, string comments)
        {
            model.editGallery(eventID, galleryID, name, type, location, comments);
        }

        public void deleteGallery(int galleryID)
        {
            model.deleteGallery(galleryID);
        }

        public GalleryNames getGalleryNames()
        {
            return model.getGalleryNames();
        }
    }
}
