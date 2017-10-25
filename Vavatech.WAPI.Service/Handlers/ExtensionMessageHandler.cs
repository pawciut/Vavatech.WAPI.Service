using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Vavatech.WAPI.Service.Handlers
{
    public class ExtensionMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var uri = request.RequestUri;
            //var extension = System.IO.Path.GetExtension(uri.AbsolutePath);
            //string acceptedType = String.Empty;
            //switch (extension)
            //{
            //    case ".png":
            //        acceptedType = "image/png";
            //        break;
            //    case ".xml":
            //        acceptedType = "application/xml";
            //        break;
            //    case "json":
            //        acceptedType = "application/json";
            //        break;
            //    default:
            //        //Not supported
            //        break;
            //}
            //HttpResponseMessage response = null;
            //if (!string.IsNullOrEmpty(acceptedType))
            //{
            //    request.Headers.Add("Accept", acceptedType);
            //    response = await base.SendAsync(request, cancellationToken);
            //}
            //else
            //    response = new HttpResponseMessage(System.Net.HttpStatusCode.UnsupportedMediaType);

            //return response;
            return await base.SendAsync(request, cancellationToken);
        }
    }
}