using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteSUPPORTASUDomain;
using System.Data.Entity;

using Contact = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.ContactU>;

namespace WebsiteSUPPORTASUCore
{

    public class ContactUsService
    {
        WebsiteSUPPORTASUDomain.websitedbEntities model;

        public ContactUsService()
        {
            model = new websitedbEntities();
        }

        public void AddContactUs(string name, string email, string subject, string Message)
        {

            model.AddContactUs(name, email, subject, Message);

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            message.From = new System.Net.Mail.MailAddress(email);
            message.To.Add(new System.Net.Mail.MailAddress("support.2013@live.com", "SUPPORT ASU"));// mail support ? 
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = subject;
            message.Body = Message;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                 e.Message.ToString();
            }
        }
        
        public Contact GetContactUs()
        {
            return model.GetContactUs();
        }

        public void DeleteContact(int ID)
        {
            model.DeleteContact(ID);
        }

        public Contact GetContacts()
        {
            return model.GetContactUs();
        }
    }
}
