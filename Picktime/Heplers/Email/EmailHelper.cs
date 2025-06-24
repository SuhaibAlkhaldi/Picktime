using Picktime.DTOs.Auth;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace Picktime.Heplers.Email
{
    public static class EmailHelper
    {
        public static async Task SendEmail(string email, string code, string title, string message, EmailConfig _emailConfig)
        {
            var apiKey = _emailConfig.EmailAPIKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_emailConfig.EmailAddress, "Example User");
            var subject = title;
            var to = new EmailAddress(email, "Example User");
            var plainTextContent = message;
            var htmlContent = "<strong>"+ code + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent , htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
        }
    
}
