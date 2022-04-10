using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Website.API
{
    public class WebsiteApiCalls : APIHelper
    {
        internal async Task<List<Salot.Data.Website>> InsertWebsiteForUser(Guid userID, string websiteAddress)
        {
            Salot.Data.Website website = new Salot.Data.Website();
            website.Address = websiteAddress;
            website.UserId = userID;
            try
            {
                HttpResponseMessage response = await ApiClient.PostAsJsonAsync(
                    "https://localhost:44318/api/website/insert", website);
                if (response.IsSuccessStatusCode)
                {
                    var user2 = await response.Content.ReadAsAsync<List<Salot.Data.Website>>();


                    return user2;
                }
                else
                {
                    var errorMessageFromApi = await response.Content.ReadAsAsync<string>();
                    throw new ArgumentException(string.Format("Error in Api: {0}", errorMessageFromApi));
                }
            }
            catch
            {
                throw;
            }
        }
        internal async Task<List<Salot.Data.Website>> GetWebsitesForUsers(Guid guid)
        {
            try
            {
                HttpResponseMessage response = await ApiClient.GetAsync(
                    $"https://localhost:44318/api/website/getuserwebsites/{guid}");
                if (response.IsSuccessStatusCode)
                {
                    var websites = await response.Content.ReadAsAsync<List<Salot.Data.Website>>();
                    return websites;
                }
                else
                {
                    var errorMessageFromApi = await response.Content.ReadAsAsync<string>();
                    throw new ArgumentException(string.Format("Error in Api: {0}", errorMessageFromApi));
                }
            }
            catch
            {
                throw;
            }
        }
        public override async Task<string> Delete(Guid guid)
        {
            try
            {
                HttpResponseMessage response = await ApiClient.DeleteAsync(
                    $"https://localhost:44318/api/website/delete/{guid}");
                if (response.IsSuccessStatusCode)
                {
                    var returnMessage = await response.Content.ReadAsAsync<string>();
                    return returnMessage;
                }
                else
                {
                    var errorMessageFromApi = await response.Content.ReadAsAsync<string>();
                    throw new ArgumentException(string.Format("Error in Api: {0}", errorMessageFromApi));
                }
            }
            catch
            {
                throw;
            }
        }
    }
}