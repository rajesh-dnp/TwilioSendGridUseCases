using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioSendGridUseCases.TransactionalTemplates.TemplatesDataModels
{
    public class ExampleTemplateData
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

    }
}
