using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace EmployeeApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "exception_log.txt");
            File.AppendAllText(logPath, $"[{DateTime.Now}] {exception.Message}{Environment.NewLine}");

            context.Result = new ObjectResult("Internal Server Error from Custom Filter")
            {
                StatusCode = 500
            };
        }
    }
}
