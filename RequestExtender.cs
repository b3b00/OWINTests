using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWINTest
{
   
        internal static class RequestExtender
        {
            public static IOwinRequest SetSData(this IOwinRequest request, string sdata )
            {
                 request.Set<string>("sdata", sdata);
                return request;
            }

        public static string GetSData(this IOwinRequest request)
        {
            return request.Get<string>("sdata");
        }
    }
    
}
