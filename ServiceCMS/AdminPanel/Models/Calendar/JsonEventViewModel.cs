using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AdminPanel.Models.Calendar
{
    public class JsonEventViewModel
    {
        [JsonProperty(PropertyName= "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "start")]
        public string Start { get; set; }
        [JsonProperty(PropertyName = "end")]
        public string End { get; set; }
         [JsonProperty(PropertyName = "editable")]
        public bool Editable {
            get { return false; }
        }

    }
}