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
        SettingsModel Get();

        ResponseBase Update(SettingsModel news);
    }
}
