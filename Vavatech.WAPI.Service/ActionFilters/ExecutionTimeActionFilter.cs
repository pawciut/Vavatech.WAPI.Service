using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Vavatech.WAPI.Service.ActionFilters
{
    public class ExecutionTimeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionName = actionContext.ActionDescriptor.ActionName;
            actionContext.Request.Properties[actionName] = Stopwatch.StartNew();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            var stopWatch = actionExecutedContext.ActionContext.Request.Properties[actionName] as Stopwatch;
            if (stopWatch != null)
            {
                stopWatch.Stop();
                actionExecutedContext.Response.Headers.Add("execution-time", stopWatch.Elapsed.ToString());
                Trace.WriteLine($"{actionName} elapsed {stopWatch.Elapsed}");
            }
        }
    }
}