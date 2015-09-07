using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Logic.Common.Models;

namespace Logic.Inset.Interfaces
{
    public interface IParser
    {
        string Tag { get; }
        TagBuilder ParserTagBuilder { get; }
        string Parse(string inset);
    }
}
