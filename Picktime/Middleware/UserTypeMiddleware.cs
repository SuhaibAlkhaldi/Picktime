using Microsoft.AspNetCore.Authorization;
using Picktime.DTOs.Auth;
using System.Security.Claims;

namespace Picktime.Middleware
{
    public class UserTypeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthorizationService _authService;

        public UserTypeMiddleware(
            RequestDelegate next,
            IAuthorizationService authService)
        {
            _next = next;
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var authorizeAttributes = endpoint?.Metadata.GetOrderedMetadata<AuthorizeUserTypeAttribute>();

            if (authorizeAttributes?.Any() == true)
            {
                var authResult = await _authService.AuthorizeAsync(
                    context.User,
                    endpoint,
                    authorizeAttributes.First().Policy);

                if (!authResult.Succeeded)
                {
                    // Simplified status code determination
                    context.Response.StatusCode = context.User.Identity?.IsAuthenticated == true
                        ? StatusCodes.Status403Forbidden  // Authenticated but not authorized
                        : StatusCodes.Status401Unauthorized;  // Not authenticated

                    // Optional: Add more detailed failure information
                    if (authResult.Failure != null)
                    {
                      //string.Join(", ", authResult.Failure.FailedRequirements));
                    }

                    return;
                }
            }

            await _next(context);
        }
    }
}
