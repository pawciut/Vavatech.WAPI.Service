using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Vavatech.WAPI.Service.Handlers
{
    public class SecretKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (IsValid(request))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                return response;
            }
        }

        bool IsValid(HttpRequestMessage reques)
        {
            if (reques.Headers.TryGetValues("Secret-Key", out IEnumerable<string> secretKeys))
            {
                return secretKeys.Contains("123");
            }
            else
                return false;
        }
    }
}