using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Interfaces
{
    public interface ILogger
    {
        string CreateErrorMessage(Exception serviceException);

        void LogToFile(string message);
    }
}
