using Microsoft.AspNetCore.Authorization;
using Picktime.Helpers.Enums;

namespace Picktime.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizeUserTypeAttribute : AuthorizeAttribute
    {
        public AuthorizeUserTypeAttribute(params UserType[] allowedTypes)
        {
            Policy = string.Join(",", allowedTypes.Select(t => t.GetDescription()));
        }
    }
}
