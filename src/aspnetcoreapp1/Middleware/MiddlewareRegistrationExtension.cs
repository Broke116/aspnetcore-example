using System;
using Microsoft.AspNetCore.Builder;

namespace aspnetcoreapp1.Middleware
{
    public static class MiddlewareRegistrationExtension
    {
        public static IApplicationBuilder UseLoggerComponent(this IApplicationBuilder builder, string username, DateTime date)
        {
            return builder.UseMiddleware<LoggerComponent>(username, date);
        }
    }
}
