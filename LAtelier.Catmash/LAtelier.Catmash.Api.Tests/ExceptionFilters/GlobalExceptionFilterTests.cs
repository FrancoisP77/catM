using FluentAssertions;
using LAtelier.Catmash.Api.ExceptionFilters;
using LAtelier.Catmash.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Net;

namespace LAtelier.Catmash.Api.Tests.ExceptionFilters
{
    public class GlobalExceptionFilterTests
    {
        [Test]
        public void Handling_a_NotFoundException_should_return_a_404_NotFound_response()
        {
            // Arrange
            var globalExceptionFilter = new GlobalExceptionFilter();
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };

            var context = new ExceptionContext(actionContext, new List<IFilterMetadata>()) { 
                Exception = new NotFoundException()
            };

            // Act
            globalExceptionFilter.OnException(context);

            // Assert
            ((ObjectResult)context.Result).StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public void Handling_an_exception_should_return_a_500_InternalServerError_response_be_default()
        {
            // Arrange
            var globalExceptionFilter = new GlobalExceptionFilter();
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };

            var context = new ExceptionContext(actionContext, new List<IFilterMetadata>());

            // Act
            globalExceptionFilter.OnException(context);

            // Assert
            ((ObjectResult)context.Result).StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
        }
    }
}
