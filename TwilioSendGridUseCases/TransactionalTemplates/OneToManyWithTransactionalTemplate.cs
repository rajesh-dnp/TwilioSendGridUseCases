using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using TwilioSendGridUseCases.TransactionalTemplates.TemplatesDataModels;

namespace TwilioSendGridUseCases.TransactionalTemplates
{
    // Send email from one user to N number of users with the user data..
    public static class OneToManyWithTransactionalTemplate
    {
        public static async void SendEmail()
        {
            // Hard coded user data..
            var users = new List<User>
            {
                new User {
                    Name = "rajesh",
                    Email = "rajesh.ccin001@gmail.com",
                    ExampleTemplateData = new ExampleTemplateData
                    {
                            City = "guntur",
                            Country = "india",
                            Firstname = "rajesh",
                            Lastname = "dnp"
                    }
                },
                new User {
                    Name = "rajesh",
                    Email = "rajesh.dnp01@gmail.com",
                    ExampleTemplateData = new ExampleTemplateData
                    {
                            City = "tenali",
                            Country = "india",
                            Firstname = "rajesh",
                            Lastname = "dnp"
                    }
                }
            };

            // tos list
            var tos = new List<EmailAddress>();

            foreach (var user in users)
            {
                tos.Add(new EmailAddress
                {
                    Email = user.Email,
                    Name = user.Name
                });
            }


            // YOUR SENDGRID_API_KEY PLACE HERE DIRECTLY OR ACCESS FROM ENVIROMENT VARIABLE.
            var apiKey = "";


            //  var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);


            // YOUR TEMPLATE ID CREATED FROM SENDGRID_DYNAMIC TEMPLATES
            var templateId = "d-98facf4dcf254f66b3af0786ef3a773d";


            // DYNAMIC DATA OF EACH USER 
            // ADDED TO TEMPLATE  |  MAKE SURE YOU HAVE ADDED your placeholders with syntax as. {{PLACEHOLDER_NAME}} IN THE TEMPLATES
            var userData = new List<Dictionary<string, string>>();

            foreach (var user in users)
            {
                userData.Add(new Dictionary<string, string> {
                    { "firstname" , user.ExampleTemplateData.Firstname },
                    { "lastname", user.ExampleTemplateData.Lastname },
                    { "country", user.ExampleTemplateData.Country },
                    { "city", user.ExampleTemplateData.City }
                });
            }


            var from = new EmailAddress("rajesh.ccin001@gmail.com", "Example User");
            var msg = CreateSingleTemplateEmailToMultipleRecipients(from, tos, templateId, userData);
            var response = await client.SendEmailAsync(msg);

            Console.WriteLine(response.StatusCode);  // check the status from console.
            Console.WriteLine(response.Headers.ToString());
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();
        }

        /// <summary>
        ///  this method will send single template email to multiple recepients with their dynamic data..
        /// </summary>
        /// <param name="from"></param>
        /// <param name="tos"></param>
        /// <param name="templateId"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        public static SendGridMessage CreateSingleTemplateEmailToMultipleRecipients(
                                                                               EmailAddress from,
                                                                               List<EmailAddress> tos,
                                                                               string templateId,
                                                                               List<Dictionary<string, string>> userData)
        {
            var msg = new SendGridMessage();
            msg.SetFrom(from);
            msg.SetTemplateId(templateId);


            for (var i = 0; i < tos.Count; i++)
            {
                msg.AddTo(tos[i], i);
                //  msg.AddSubstitutions(substitutions[i], i);
                msg.SetTemplateData(userData[i], i);
            }

            return msg;
        }
    }
}
