using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Salot.Data;

namespace Salot.Helpers
{
    public class WebsiteHelper : IHelperBase
    {
        static string[] weekdayString = new string[] { "maanantai", "tiistai", "keskiviikko", "torstai", "perjantai", "monday", "tuesday", "wednesday", "thursday", "friday" };

        public static WebsiteData ReadWebsiteData(string website)
        {

            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Headers.Add("User-Agent: Other");
            byte[] raw = wc.DownloadData(website);

            string webData = System.Text.Encoding.UTF8.GetString(raw);

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(System.Text.Encoding.UTF8.GetString(raw));

            var restaurantNameFromTitle = htmlDoc.DocumentNode.SelectSingleNode("//head/title").InnerText;

            string[] div = new string[] { "div" };
            var withdiv = webData.Split(div, StringSplitOptions.RemoveEmptyEntries);

            List<EmailMessage> processedMessages = new List<EmailMessage>();
        
            int dayCounter = 0;
            bool processAsOneList = false;
            foreach (string divString in withdiv)
            {
                if (weekdayString.Any(divString.ToLower().Contains))
                {
                    Console.WriteLine();
                    dayCounter++;
                }
                if (weekdayString.Count(divString.ToLower().Contains) > 1)
                {
                    WholeListInOneString(divString, processedMessages);
                    break;
                }
                else if (dayCounter > 0 && dayCounter < 10 && !processAsOneList)
                {
                    string againProcessedString = Remove(divString, "<", ">");
                    againProcessedString = Remove(againProcessedString, "class", ">");
                    againProcessedString = againProcessedString.Replace("class", "");
                    againProcessedString = Regex.Replace(againProcessedString, @"(\s+|@|&|'|\(|\)|<|>|#|=|/|\\|\"")", "");
          
                    if (againProcessedString.Length > 5)
                    {
                        processedMessages.Add(new EmailMessage { Menu = againProcessedString, DayOfWeek = (DayOfWeek)dayCounter });
                    }
                }
            }

            return new WebsiteData { LunchMenuFromWebsite = string.Join(", ", processedMessages.Where(p => p.DayOfWeek == DateTime.Today.DayOfWeek).Select(p => p.Menu)), RestaurantName = restaurantNameFromTitle };
        }
        private static List<EmailMessage> WholeListInOneString(string divString, List<EmailMessage> processedStrings)
        {
            char[] separator = new char[] { '>', '<' };
            string[] splittedString = divString.Split(separator);
            splittedString = splittedString.Where(s => s.Length > 4).ToArray();
            int dayCounter = 1;
            foreach (string dividedString in splittedString)
            {
                if (weekdayString.Any(dividedString.ToLower().Contains))
                {
                    Console.WriteLine();
                    dayCounter++;
                }
                if (dayCounter > 0 && dayCounter < 8)
                {
                    string againProcessedString = Remove(dividedString, "<", ">");
                    againProcessedString = Remove(againProcessedString, "class", ">");
                    againProcessedString = againProcessedString.Replace("class", "");
                    againProcessedString = Regex.Replace(againProcessedString, @"(\s+|@|&|'|<|>|#|=|/|\\)", "");
                    if (againProcessedString.StartsWith("img"))
                        continue;
                    if (againProcessedString.Length > 5)
                    {
                        Console.WriteLine(againProcessedString);
                        processedStrings.Add(new EmailMessage { Menu = againProcessedString, DayOfWeek = (DayOfWeek)dayCounter });
                    }
                }
            }
            return processedStrings;
        }

        private static string Remove(string original, string firstTag, string secondTag)
        {
            string pattern = firstTag + "(.*?)" + secondTag;
            Regex regex = new Regex(pattern, RegexOptions.RightToLeft);

            foreach (Match match in regex.Matches(original))
            {
                original = original.Replace(match.Groups[1].Value, string.Empty);
            }

            return original;
        }
        public static Data.Website ConverToWebsite(object[] fromDB)
        {
            Salot.Data.Website website = new Salot.Data.Website();

            website.ID = Guid.Parse(fromDB[0].ToString());
            website.Address = fromDB[1].ToString();
            //website.Lunch = (bool)fromDB[2];
            website.UserId = (Guid)fromDB[3];
            return website;
        }
    }
}
