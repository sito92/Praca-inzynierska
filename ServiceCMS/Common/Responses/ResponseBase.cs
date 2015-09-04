using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class ResponseBase
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
    }
}
