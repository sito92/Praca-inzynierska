using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modules.Resources;

namespace AdminPanel.Models.Settings
{
    public class SettingsViewModel 
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public string InputType { get; set; }

        public string Name {
            get
            {
                return
                    string.IsNullOrEmpty(Presentation.ResourceManager.GetString(Key))
                        ? Key
                        : Presentation.ResourceManager.GetString(Key);

            }
        }

    }
}
