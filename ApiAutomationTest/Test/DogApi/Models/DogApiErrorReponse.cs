using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.DogApi.Models
{
    class DogApiErrorReponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public int code { get; set; }
    }


}
