using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Vavatech.WAPI.Service.Handlers
{
    public class TraceMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var cookies = request.Headers.GetCookies();

            Trace.WriteLine($"{request.Method}: {request.RequestUri}");

            var response = await base.SendAsync(request, cancellationToken);

            Trace.WriteLine($"{response.StatusCode}: {response.ReasonPhrase}");

            return response;
        }
    }
}