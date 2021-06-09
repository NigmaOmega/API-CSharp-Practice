using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.ExchangeRate.Model
{
    class ExchangeRateErrorResponse
    {
        public string result { get; set; }

        [JsonProperty("error-type")]
        public string ErrorType { get; set; }
    }
}
