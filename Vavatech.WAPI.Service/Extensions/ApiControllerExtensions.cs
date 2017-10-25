using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.Service.ActionResults;

namespace Vavatech.WAPI.Service.Extensions
{
    public static class ApiControllerExtensions
    {
        public static IHttpActionResult MyResult(this ApiController controller)
        {
            return new CustomActionResult();
        }
    }
}