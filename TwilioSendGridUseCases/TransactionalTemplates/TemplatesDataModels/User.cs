using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioSendGridUseCases.TransactionalTemplates.TemplatesDataModels
{
    public class User
    {
        // sample user for sending email..
        public string Email { get; set; }
        public string Name { get; set; }

        public ExampleTemplateData ExampleTemplateData { get; set; }
    }
}
