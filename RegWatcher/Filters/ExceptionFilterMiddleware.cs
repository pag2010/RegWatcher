﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RegWatcher.Filters
{
    public class ExceptionFilterMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionFilterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var exceptionType = exception.GetType();
            var errorDetails = new { Message = JsonConvert.SerializeObject(exception.Message.ToString()) };

            if (exceptionType == typeof(InvalidOperationException))
            {

                context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return context.Response.WriteAsync(errorDetails.ToString());
        }


    }
}
