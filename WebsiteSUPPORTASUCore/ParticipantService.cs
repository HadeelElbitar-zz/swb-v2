// -----------------------------------------------------------------------
// <copyright file="ParticipantService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WebsiteSUPPORTASUCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Participant = System.Data.Objects.ObjectResult<WebsiteSUPPORTASUDomain.Participant>;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ParticipantService
    {
        WebsiteSUPPORTASUDomain.websitedbEntities Model;

        public ParticipantService()
        {
            Model = new WebsiteSUPPORTASUDomain.websitedbEntities();
        }

        public string UniqueParticipant(string Value)
        {
            return Model.UniqueParticipant(Value).FirstOrDefault();
        }

        public string AddParticpant(string FullName, string Mobile, string EmailTo, string HomePhone, int College, int University, int Workshop, int Interview, int EventID, string Barcode, string Comments, int MemberID)
        {
            Model.AddParticipant(FullName, Mobile, EmailTo, HomePhone, College, University, Workshop, Interview, EventID, "", Comments, DateTime.Now);
            
            int? ID = Model.GetParticipantID(Mobile).FirstOrDefault();
            Random Rand = new Random();
            string barcode = Barcode + ID.ToString();
            barcode += "-" + Rand.Next().ToString();
            Model.AddParticipantBarcode(barcode, ID);
            Model.AddMemberID(ID, MemberID);

            string EmailFrom = "supp.f1.ort@gmail.com";
            string Subject = "Welcome to Droop Off Conference";
            string Body = "Dear: " + FullName + "<br/><br/>" +
"Congratulations! We are pleased to accept you to join “Droop Off” conference.<br/>"
+ "The conference will be tomorrow from 10:00 am to 6:00 pm in Palestine hall at The Faculty of Engineering, Ain Shams University<br/><br/>"
+ "<h2>Waiting for you tomorrow</h2><br/><br/>" +
"<br/>If you have any further questions (queries) or comments, please feel free (don't hesitate) to contact us anytime on any of the following links:<br/>" +
"Our Website: www.support-asu.org <br/>"+   
"Our Facebook page: https://www.facebook.com/SUPPORT.FCIS <br/>" +      
"Our Twitter account: https://twitter.com/#!/SupportASU    <br/>" +
"<br/><br/>Yours sincerely,<br/>" +
"<br/>HR-TEAM<br/>" +
"SUPPORT’13 “Droop Off Conference<br/>";

            SendEMail(EmailFrom, EmailTo, Subject, Body);
            return barcode;
        }

        public void SetLogOn(string barcode, bool p)
        {
            Model.AddParticipantLogOn(barcode, p);
        }

        public bool? GetLogedOn(string p)
        {
            return Model.GetParticipantLogOn(p).FirstOrDefault();
        }

        public WebsiteSUPPORTASUDomain.Participant GetParticipant(string p)
        {
            return Model.GetParticipant(0, p).FirstOrDefault();
        }

        public void AddHRComment(string Barcode, string Form)
        {
            Model.AddHRComment(Barcode, Form);
        }

        public string SendEMail(string EmailFrom, string EmailTo, string Subject, string Body)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            message.From = new System.Net.Mail.MailAddress(EmailFrom, "SUPPORT ASU");
            message.To.Add(new System.Net.Mail.MailAddress(EmailTo));
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = Subject;
            message.Body = Body;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            try
            {
                client.Send(message);
                return "Done";
            }
            catch (Exception e)
            {
                return "Not";
            }
        }

        public string SendEMail(string FullName, string EmailTo, string Barcode)
        {
            string Subject = "Welcome to Droop Off Conference";
            string Body = "Dear: " + FullName + "<br/><br/>" +
"Thank you for your registration for “Droop Off” conference. We are so pleased with your request of joining “Droop Off” conference <br/><br/>" +
"Thank you for joining “Droop Off” conference. <br/>" +
"Please for security issues use this link below Instead of the previous one. <br/>" +
"<br/>" +
"http://support-asu.org/Registration/DroopOffLogOn" +
"<br/>" +
"<br/><br/>You will receive a new e-mail which contains a new barcode soon.<br/>" +
"<br/>If you have any further questions (queries) or comments, please feel free (don't hesitate) to contact us anytime on any of the following links:<br/>" +
"Our Website: www.support-asu.org <br/>" +
"Our Facebook page: https://www.facebook.com/SUPPORT.FCIS <br/>" +
"Our Twitter account: https://twitter.com/#!/SupportASU    <br/>" +
"<br/><br/>Yours sincerely,<br/>" +
"<br/>IT-TEAM<br/>" +
"SUPPORT’13 “Droop Off<br/>";

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.From = new System.Net.Mail.MailAddress("supp.f1.ort@gmail.com", "SUPPORT ASU");
            message.To.Add(new System.Net.Mail.MailAddress(EmailTo));
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = Subject;
            message.Body = Body;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            try
            {
                client.Send(message);
                return "Done";
            }
            catch (Exception e)
            {
                return "Not";
            }
        }

        public string SendEMail(string FullName, string EmailTo)
        {
            string Subject = "Welcome to Droop Off Conference";
            string Body = "Dear: " + FullName + "<br/><br/>" +
"Congratulations! We are pleased to accept you to join “Droop Off” conference.<br/>"
+ "The conference will be tomorrow from 10:00 am to 6:00 pm in Palestine hall at The Faculty of Engineering, Ain Shams University<br/><br/>"
+ "<h2>Waiting for you tomorrow</h2><br/><br/>" +
"<br/>If you have any further questions (queries) or comments, please feel free (don't hesitate) to contact us anytime on any of the following links:<br/>" +
"Our Website: www.support-asu.org <br/>" +
"Our Facebook page: https://www.facebook.com/SUPPORT.FCIS <br/>" +
"Our Twitter account: https://twitter.com/#!/SupportASU    <br/>" +
"<br/><br/>Yours sincerely,<br/>" +
"<br/>HR-TEAM<br/>" +
"SUPPORT’13 “Droop Off Conference<br/>";

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.From = new System.Net.Mail.MailAddress("supp.f1.ort@gmail.com", "SUPPORT ASU");
            message.To.Add(new System.Net.Mail.MailAddress(EmailTo));
            message.CC.Add(new System.Net.Mail.MailAddress("supp.f1.ort@gmail.com", "SUPPORT ASU"));
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = Subject;
            message.Body = Body;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            try
            {
                client.Send(message);
                return "Done";
            }
            catch (Exception e)
            {
                return "Not";
            }
        }

        public Participant GetHRCommentsSeen()
        {
            return Model.GetHRSeenComments();
        }

        public Participant GetHRCommentSeen(string p)
        {
            return Model.GetHRSeenComment(p);
        }

        public Participant GetHRComments()
        {
            return Model.GetHRComments();
        }

        public String FirstFormFill(string p)
        {
            return Model.FirstFormFill(p).FirstOrDefault();
        }

        public List<WebsiteSUPPORTASUDomain.Participant> GetOffParticipants()
        {
            return Model.GetOffParticipants().ToList();
        }

        public List<WebsiteSUPPORTASUDomain.Participant> GetParticipants()
        {
            return Model.GetParticipants().ToList() ;
        }
    }
}
