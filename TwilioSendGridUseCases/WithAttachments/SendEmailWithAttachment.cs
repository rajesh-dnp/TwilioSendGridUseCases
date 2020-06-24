using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;

namespace TwilioSendGridUseCases.WithAttachments
{
    public static class SendEmailWithAttachment
    {
        public static async void SendEmail()
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("rajesh.ccin001@gmail.com");
            var subject = "Subject";
            var to = new EmailAddress("rajesh.ccin001@gmail.com");
            var body = "Email Body";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, "");
            var bytes = File.ReadAllBytes("C:\\EMAIL\\TEST.TXT");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("file.pdf", file);
            var response = await client.SendEmailAsync(msg);
        }

    }
}
