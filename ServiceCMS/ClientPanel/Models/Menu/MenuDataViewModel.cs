using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic.Common.Models;

namespace ClientPanel.Models.Menu
{
    public class MenuDataViewModel
    {
        public string CompanyName { get; set; }
        public List<MenuButtonModel> Buttons { get; set; }
    }
}