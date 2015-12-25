using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Models.Settings
{
    public class ListSettingsViewModel 
    {
        public List<SettingsViewModel> Settings { get; set; }
         
        public ListSettingsViewModel()
        {
            
        }

        public ListSettingsViewModel(Dictionary<string, Tuple<object, string>> settings)
        {
            Settings = new List<SettingsViewModel>();

            foreach (var setting in settings)
            {
                Settings.Add(new SettingsViewModel(){Key = setting.Key,Value = setting.Value.Item1,InputType = setting.Value.Item2});
            }
        }

        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string,string> result = new Dictionary<string, string>();

            foreach (var settting in Settings)
            {
                var key = settting.Key;
                var value = settting.Value.ToString();
                result.Add(key,value);
            }

            return result;
        }

    }
}
