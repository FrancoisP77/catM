using LAtelier.Catmash.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LAtelier.Catmash.Api.ExceptionFilters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            /* We may want to add some logging here */

            HttpStatusCode status = context.Exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };

            context.Result = new ObjectResult(null)
            { StatusCode = (int)status };

            base.OnException(context);
        }
    }
}
