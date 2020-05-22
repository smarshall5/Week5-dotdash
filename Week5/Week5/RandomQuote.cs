using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Week5
{
    class RandomQuote
    {

        [JsonProperty("value")]
        public string quote { get; set; }
        public string author { get; set; }
        
        public string category { get; set; }
    }
}
