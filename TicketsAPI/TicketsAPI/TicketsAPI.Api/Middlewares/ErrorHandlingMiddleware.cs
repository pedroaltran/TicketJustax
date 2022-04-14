using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TicketsAPI.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Construtor do middleware
        /// </summary>
        /// <param name="next">Request Delegate</param>
        public ErrorHandlingMiddleware(RequestDelegate next) => this.next = next;

        /// <summary>
        /// Invocar o error handler
        /// </summary>
        /// <param name="context">contexto</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handle exception
        /// </summary>
        /// <param name="context">Contexto</param>
        /// <param name="exception">Exception</param>
        /// <returns>Task</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.BadRequest;
            var errorResult = exception.InnerException?.Message ?? exception.Message;

            context.Response.ContentType = "plain/text";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = errorResult }));
        }
    }
}
