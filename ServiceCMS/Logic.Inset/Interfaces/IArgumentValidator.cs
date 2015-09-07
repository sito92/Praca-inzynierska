using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Logic.Inset.Interfaces
{
    public interface IArgumentValidator
    {
        bool IsValid(InsetArgumentTypeEnum argumentType, string value);
    }
}
