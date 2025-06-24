using Picktime.DTOs.Auth;

namespace Picktime.Middleware
{

    public class MacAddressMiddleware
    {
        private readonly RequestDelegate _next;

        public MacAddressMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context , BaseDTO baseDTO)
        {
      
                baseDTO.MacAddress = GetClientIdentifier(context);
                await _next(context);
        }

        private string GetClientIdentifier(HttpContext context)
        {
            // 1. Try to get from headers (if provided by reverse proxy)
            if (context.Request.Headers.TryGetValue("X-Device-Mac", out var macHeader))
                return macHeader.ToString();

            // 2. Fallback to IP-based fingerprint
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var userAgent = context.Request.Headers.UserAgent.ToString();
            return $"IP:{ip}-UA:{userAgent}";
        }
    }
}
