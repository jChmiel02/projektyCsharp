using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace NASAWebService
{
    public class ClientTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ClientTokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("Client-Token", out var token) ||
                !IsValidClientToken(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Incorrect or missing: Client-Token");
                return;
            }

            await _next(context);
        }

        private bool IsValidClientToken(string token)
        {
            var validToken = _configuration["ClientToken"];
            return token == validToken;
        }
    }
}
