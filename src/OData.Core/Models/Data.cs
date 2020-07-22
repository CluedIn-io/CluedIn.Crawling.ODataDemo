using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CluedIn.Crawling.OData.Core.Models
{
    public class Data
    {
        [JsonProperty("accountid")]
        public string AccountId { get; set; }

        [JsonProperty("accountname")]
        public string AccountName { get; set; }

        [JsonProperty("address1_addressid")]
        public string Address1AddressId { get; set; }

        [JsonProperty("address1_city")]
        public string Address1City { get; set; }

        [JsonProperty("address1_composite")]
        public string Address1Composite { get; set; }

        [JsonProperty("address1_country")]
        public string Address1Country { get; set; }

        [JsonProperty("createdbyname")]
        public string CreatedByName { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

    }
}
