using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace aspnetcoreapp1.Middleware
{
    public class LoggerComponent
    {
        private readonly RequestDelegate _next;
        private readonly string _username;
        private readonly DateTime _date;

        public LoggerComponent(RequestDelegate next, string username, DateTime date)
        {
            _next = next;
            _username = username;
            _date = date;
        }

        public async Task Invoke(HttpContext context)
        {
            Debug.WriteLine($"Hello from the logger component: {_username}, {_date}");
            await _next(context);
        }
    }
}
