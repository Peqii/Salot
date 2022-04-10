using Salot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Website.API
{
    interface IApiHelper<T> where T : IDatarecordBase
    {
         Task<string> Delete(Guid guid);

    }
}