using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.ConstStrings;
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
                InsetArgumentTypeEnum.Int, x =>
                {
                int n;
                return int.TryParse(x, out n);
                }
            },
            {
                InsetArgumentTypeEnum.String, x=>true
            },
            {
                InsetArgumentTypeEnum.IntCollection, x =>
                {
                    int n;
                    var arguments = Regex.Split(x, RegularExpressions.ArgumentCollectionSeparator,
                        RegexOptions.ExplicitCapture);

                    return arguments.All(argument => int.TryParse(argument,out n));
                }
            }
        };
        public bool IsValid(InsetArgumentTypeEnum argumentType, string value)
        {
            return validateFuncs[argumentType](value);
        }
    }
}
