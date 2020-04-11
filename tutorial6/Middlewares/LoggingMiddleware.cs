using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace tutorial6.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string path = httpContext.Request.Path;
            string queryString = httpContext.Request?.QueryString.ToString();
            string method = httpContext.Request.Method.ToString();
            string bodyParameters = "";

            using (StreamReader reader  = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyParameters = await reader.ReadToEndAsync();

                string log = "log.txt";
            
                if(!File.Exists(log))
                {
                    File.Create(log);
                }

                using (StreamWriter writer = new StreamWriter(log))
                {
                    writer.WriteLine("Path: " + path);
                    writer.WriteLine("Query String: " + queryString);
                    writer.WriteLine("Method: " + method);
                    writer.WriteLine("Body Parameters: " + bodyParameters);
                    writer.Close();
                }
            }
            await _next(httpContext);
        }
    }
}