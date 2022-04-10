using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlTags;

namespace EmailSender._365
{
    public class EWSExchangeHelper
    {
        public EWSExchangeHelper(EWSAuthenticationInfo credentialInfo)
        {
            ExchangeService service = new ExchangeService();
            service.Credentials = new WebCredentials(credentialInfo.ExchangeUsername, credentialInfo.ExchangeUserPassword);
            service.Url = new Uri(credentialInfo.ExchangeServiceUrl);
            this.ExchangeService = service;
        }

        protected ExchangeService ExchangeService { get; }

        public void SendEmail(string toReceipient, string subject, string body)
        {
            EmailMessage message = new EmailMessage(ExchangeService)
            {
                Subject = subject,
                Body = new MessageBody(BodyType.Text, body),
                Importance = Importance.Normal,
            };
            message.ToRecipients.Add(toReceipient);
            message.SendAndSaveCopy();

        }

        internal void SendDailyEmailsForUser(Guid recipient, List<Salot.Data.WebsiteData> menusForToday)
        {
            if(recipient != Guid.Empty)
            {
                string recipientEmail = SQLHandler.GetUserEmail(recipient);
                if(!string.IsNullOrEmpty(recipientEmail))
                {
                    string body = CreateEmailBodyFromList(menusForToday);
                    EmailMessage message = new EmailMessage(ExchangeService)
                    {
                        Subject = "Here is your daily menu suggestions",
                        Body = new MessageBody(BodyType.HTML, body),
                        Importance = Importance.Normal,
                    };
                    try
                    {
                        message.ToRecipients.Add(recipientEmail);
                        message.SendAndSaveCopy();
                    }
                    catch(Exception ex)
                    {
                        //TODO: Logitus
                    }
                }
            }
        }

        private string CreateEmailBodyFromList(List<Salot.Data.WebsiteData> menusForToday)
        {
            string fullMenu = string.Empty;

            var tag = new HtmlTag("title");
            tag.Text("Lounaslista tänään");
            tag.AddClass("important");
            fullMenu = string.Concat(fullMenu, tag);
            var tag3 = new HtmlTag("h1");
            tag3.Text($@"Lounaslista {DateTime.Today.DayOfWeek} {DateTime.Today.Date}");
            fullMenu = string.Concat(fullMenu, tag3);
            foreach (Salot.Data.WebsiteData websiteData in menusForToday)
            {
                var titleTag = new HtmlTag("h2");
                titleTag.Text(websiteData.RestaurantName);
                fullMenu = string.Concat(fullMenu, titleTag);

                var textTag = new HtmlTag("p");
                textTag.Text(websiteData.LunchMenuFromWebsite);
                fullMenu = string.Concat(fullMenu, textTag);
            }
            return fullMenu;
        }
    }
}
