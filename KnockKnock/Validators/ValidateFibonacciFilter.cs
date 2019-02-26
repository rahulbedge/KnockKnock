using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Validators
{
    public class ValidateFibonacciFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if( !context.HttpContext.Request.Query.Keys.Contains("n"))
            {
                context.HttpContext.Response.StatusCode = 404;
                context.Result = new JsonResult(new
                {
                    message = string.Format(Constants.RESOURCE_NOT_FOUND,
                        UriHelper.GetDisplayUrl(context.HttpContext.Request))
                });
                return;
            }
            else if (context.ActionArguments.Count <= 0 || !context.ActionArguments.ContainsKey("number"))
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult(new { message = Constants.INVALID_REQUEST });
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
