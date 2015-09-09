using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Logic.Common.Models;

namespace Logic.Inset.Interfaces
{
    public interface IInsetService
    {
        InsetModel GetByName(string name);

        IList<InsetModel> GetAll();
    }
}
