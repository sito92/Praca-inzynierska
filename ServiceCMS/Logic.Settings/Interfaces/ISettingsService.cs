using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.Settings.Interfaces
{
    public interface ISettingsService
    {
        Dictionary<string, Tuple<object, string>> GetAll(); 

        string GetPropertyByName(string name);

        ResponseBase Update(Dictionary<string, string> mailSettings);
    }
}
