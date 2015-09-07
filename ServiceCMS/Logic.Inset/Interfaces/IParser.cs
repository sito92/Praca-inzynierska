using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Common.Models;

namespace Logic.Inset.Interfaces
{
    public interface IParser
    {
        string Parse(string inset);
    }
}
