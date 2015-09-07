using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Logic.Inset.Interfaces;

namespace Logic.Inset.Services
{
    public class ArgumentValidator : IArgumentValidator
    {
        private Dictionary<InsetArgumentTypeEnum, Func<string, bool>> validateFuncs = new Dictionary
            <InsetArgumentTypeEnum, Func<string, bool>>()
        {
            {
                InsetArgumentTypeEnum.Number, x =>
                {
                int n;
                return int.TryParse(x, out n);
                }
            },
            {
                InsetArgumentTypeEnum.String, x=>true
            }
        };
        public bool IsValid(InsetArgumentTypeEnum argumentType, string value)
        {
            return validateFuncs[argumentType](value);
        }
    }
}
