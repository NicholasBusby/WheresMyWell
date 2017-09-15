using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheres_My_Well.Models
{
    public class Well
    {
        [JsonProperty("api")]
        public string APINumber { get; set; }
        [JsonProperty("api_no")]
        public string FormattedAPINumber { get; set; }
        [JsonProperty("operator")]
        public string OperatorName { get; set; }
        [JsonProperty("well_name")]
        public string WellName { get; set; }
        [JsonProperty("field_name")]
        public string FieldName { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("County")]
        public string County { get; set; }
    }
}
