// -----------------------------------------------------------------------
// <copyright file="EventService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WebsiteSUPPORTASUCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebsiteSUPPORTASUDomain;
    using System.Data.Entity;

    using Event = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Event>;
    using EventsNames = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.EventsName>;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EventService
    {
        WebsiteSUPPORTASUDomain.websitedbEntities Domain;
       
        public EventService()
        {
            Domain = new websitedbEntities();
        }

        public Event GetEvents()
        {
            return Domain.GetEvents();
        }

        public Event GetEvent(int id)
        {
            return Domain.GetEvent(id);
        }

        public void AddEvent(string Name, DateTime StartDate, DateTime EndDate, string Description, string ShortDescription, string Comments)
        {
            Domain.AddEvent(Name, StartDate, EndDate, Description, ShortDescription, Comments);
        }

        public EventsNames GetEventsNames()
        {
            return Domain.GetEventsNames();
        }

        public int DeleteEvent(int id)
        {
            return Domain.DeleteEvent(id);
        }

        public void EditEvent(int ID, string Name, DateTime StartDate, DateTime EndDate, string Description, string ShortDescription, string Comments)
        {
            Domain.EditEvent(ID, Name, StartDate, EndDate, Description, ShortDescription, Comments);
        }
    
    }
}
