using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteSUPPORTASUDomain;

using subscribe = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Subscribe>;

namespace WebsiteSUPPORTASUCore
{
    public class SubscribeService
    {
        WebsiteSUPPORTASUDomain.websitedbEntities model;
        
        public SubscribeService()
        {
            model = new websitedbEntities();
        }

        public bool AddSubscribe(String name, string email, int state)
        {
            Subscribe subscribe = model.GetSubscriberbyEmail(email).FirstOrDefault();
            if (subscribe == null)
                model.AddSubscriper(name, email, state.ToString());
            else
                return false;
            return true;

        }

        public subscribe GetSubscribe(int id)
        {
            return model.GetSubscriber(id);
        }

        public void DeleteSubscribe(int id)
        {
            model.DeleteContact(id);
        }
        
        public void EditSubscribe(int id, int state)
        {
            model.EditSubscripers(id, state);
        }



    }
}
