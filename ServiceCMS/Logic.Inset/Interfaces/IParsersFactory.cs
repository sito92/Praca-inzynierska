using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Inset.Interfaces
{
    public interface IParsersFactory
    {
        IParser GetParser(string name);
    }
}
