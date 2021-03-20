﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi_NVV_Books.Data.ViewModels;

namespace WebApi_NVV_Books.Exception
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) 
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, System.Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var response = new ErrorVM()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message ="Internal Server Error from the custom middleware",
                Path = "path-goes-here"
            };

            return httpContext.Response.WriteAsync(response.ToString());
        }
    }
}
