using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Statistics.Interfaces
{
    public interface IStatistics
    {
        bool IsEntryUnique(object userEntry);

        string GetCountryPerIpAddress(string ip);
    }
}
