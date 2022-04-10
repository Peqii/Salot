using Salot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
namespace Website.API
{
    public class APIHelper : IApiHelper<IDatarecordBase>
    {
        public HttpClient ApiClient { get; set; }
        public APIHelper()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public virtual async Task<string> Delete(Guid guid)
        {
            throw new NotImplementedException("Implement in derived class");
        }
    }
}