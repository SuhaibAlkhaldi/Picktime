using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace Picktime.Heplers.Email
{
    public static class EmailHelper
    { 
        public static async Task SendEmail(string email, string code, string title, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("suhaibamjad73@gmail.com", "PickTime Admin");
            var subject = title;
            var to = new EmailAddress(email, "PickTime User");
            var plainTextContent = "";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, "");
            var response = await client.SendEmailAsync(msg);
        }
    }
    
}
