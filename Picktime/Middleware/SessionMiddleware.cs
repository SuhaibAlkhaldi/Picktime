using Newtonsoft.Json;
using Picktime.DTOs.JWT;
using Picktime.DTOs.Auth;

namespace Picktime.Middleware
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate next;
        public SessionMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public async Task Invoke(HttpContext context, SessionProvider sessionProvider)
        {
            sessionProvider.InitialiseClientInfo(new ClientInfo(context.Connection.RemoteIpAddress.ToString(), context.Connection.RemotePort));

            string Lang = context.Request.Headers["Language"];
            sessionProvider.InitialiseLanguageInfo(Lang);

            bool isAuthenticated = context.User != null && context.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                var userClaimSerialized = context.User.FindFirst(UserSettingsClaimTypes.LoggedInUser);
                if (userClaimSerialized != null)
                {
                    var user = JsonConvert.DeserializeObject<LoggedInUser>(userClaimSerialized.Value);
                    if (user != null)
                    {
                        sessionProvider.InitialiseCurrentUser(user);
                    }
                }
            }
            await next(context);
        }
    }
}
