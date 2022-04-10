using Salot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Website.API
{
    public class UserApiCalls : APIHelper
    {
         
        public async Task<List<User>> Login(IDatarecordBase user)
        {    
            try
            {
                HttpResponseMessage  response = await ApiClient.PostAsJsonAsync(
                    "https://localhost:44318/api/user/Login", (User)user);
                if (response.IsSuccessStatusCode)
                {
                    var user2 = await response.Content.ReadAsAsync<List<User>>();
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

        internal async Task<User> RegisterUser(string email, string password)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;

            try
            {
                HttpResponseMessage response = await ApiClient.PostAsJsonAsync(
                    "https://localhost:44318/api/user/register", user);
                if (response.IsSuccessStatusCode)
                {
                    var user2 = await response.Content.ReadAsAsync<User>();
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
    }
}