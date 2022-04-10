using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Office365;
//using Microsoft.Office365.OutlookServices;
using System.Timers;
using Microsoft.Exchange.WebServices;
using Microsoft.Exchange.WebServices.Data;
using Salot.Helpers;

namespace EmailSender._365
{
    class OutlookHandler
    {
        Timer _timer;
        DateTime _lastRun;
        public void InitOutlookConnection()
        {
            
            _timer = new Timer(100000 * 6 * 24); // every 10 minutes??
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            _timer.Start();
#if DEBUG
            _timer = new Timer(10000); // every 10 minutes??
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            _timer.Start();
#endif
           
        }
        public static EWSAuthenticationInfo InitEWSAuthenticationInfo(object[] values)
        {
            EWSAuthenticationInfo eWSAuthenticationInfo = new EWSAuthenticationInfo
            {
                ExchangeClientId = values[1].ToString(),
                ExchangeClientSecret = values[2].ToString(),
                ExchangeServiceUrl = values[3].ToString(),
                ExchangeTenantId = values[4].ToString(),
                ExchangeUsername = values[5].ToString(),
                ExchangeUserPassword = values[6].ToString(),
            };

            return eWSAuthenticationInfo;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();

            try
            {
                EWSExchangeHelper eWSExchangeHelper =  new EWSExchangeHelper(SQLHandler.GetExchangeInformation());

                List<Salot.Data.Website> websites = SQLHandler.GetWebsites();

                var websitesGroupedByUsers = websites.GroupBy(w => w.UserId);
                List<Salot.Data.WebsiteData> menusForToday = new List<Salot.Data.WebsiteData>();

                foreach (var group in websitesGroupedByUsers)
                {
                    foreach (var website in group)
                        menusForToday.Add(WebsiteHelper.ReadWebsiteData(website.Address));
                    
                    eWSExchangeHelper.SendDailyEmailsForUser(group.Key ?? Guid.Empty, menusForToday);
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }

            _lastRun = DateTime.Now;
            _timer.Start();
        }
    }
}
