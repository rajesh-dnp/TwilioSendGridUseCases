using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioSendGridUseCases.TransactionalTemplates
{
    public static class OneToOneWithTransactionalTemplate
    {
        public static async void SendEmail()
        {
            // get api key from environment variable..

            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("test@example.com", "Example User"));
            msg.AddTo(new EmailAddress("test@example.com", "Example User"));

            // replace with your template id
            msg.SetTemplateId("d-d42b0eea09964d1ab957c18986c01828");

            var dynamicTemplateData = new TemplatesDataModels.ExampleTemplateData
            {
                Firstname = "rajesh",
                Lastname = "donepudi",
                City = "Guntur",
                Country = "India"
            };

            msg.SetTemplateData(dynamicTemplateData);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers.ToString());
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
