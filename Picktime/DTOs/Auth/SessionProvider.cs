using Picktime.Helpers.Enums;

namespace Picktime.DTOs.Auth
{
    public class SessionProvider
    {
        public bool IsAuthenticated { get; private set; }
        public LoggedInUser CurrentUser { get; private set; }
        public ClientInfo ClinetInfo { get; private set; }
        public ELanguage Language { get; private set; }

        public SessionProvider()
        {
            IsAuthenticated = false;
            CurrentUser = new LoggedInUser();
            ClinetInfo = new ClientInfo();
        }
        public void InitialiseCurrentUser(LoggedInUser user)
        {
            CurrentUser = user;
            IsAuthenticated = true;
        }
        public void InitialiseClientInfo(ClientInfo info)
        {
            ClinetInfo = info;
        }
        public void InitialiseLanguageInfo(string language)
        {
            if (language is not null)
            {
                Language = language.ToLower().Trim().Equals("en") ? ELanguage.English : ELanguage.Arabic;
            }
            else
            {
                Language = ELanguage.English;
            }
        }

    }
}
