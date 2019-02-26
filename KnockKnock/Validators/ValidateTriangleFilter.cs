using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Validators
{
    public class ValidateTriangleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if( !context.HttpContext.Request.Query.Keys.Contains("a") ||
                !context.HttpContext.Request.Query.Keys.Contains("b")||
                !context.HttpContext.Request.Query.Keys.Contains("c")
                )
            {
                context.HttpContext.Response.StatusCode = 404;
                context.Result = new JsonResult(new{message = $"No HTTP resource was found that matches " +
                    $"the request URI '{UriHelper.GetDisplayUrl(context.HttpContext.Request)}'." });
                return;
            }
            else if (context.ActionArguments.Count < 3 || 
                !context.ActionArguments.ContainsKey("a") ||
                !context.ActionArguments.ContainsKey("b") ||
                !context.ActionArguments.ContainsKey("c"))
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult(new { message = "The request is invalid." });
                return;
            }
            else
            {
                // all right conditions Do nothing!!!
            }
            base.OnActionExecuting(context);
        }
    }
}
