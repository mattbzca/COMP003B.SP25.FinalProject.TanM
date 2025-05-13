using System.Diagnostics;

namespace COMP003B.SP25.FinalProject.TanM.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var executetime = Stopwatch.StartNew();
            Console.WriteLine($"[Request] {context.Request.Method} {context.Request.Path}");
            await _next(context);
            executetime.Stop();
            Console.WriteLine($"[Response] {context.Response.StatusCode}, Execute Time: {executetime.ElapsedMilliseconds}ms");
        }
    }
}
