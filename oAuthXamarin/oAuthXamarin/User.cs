using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace oAuthXamarin
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("given_name")]
        public string FirstName { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("picture")]
        public Uri Picture { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
