using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.Service.Interfaces
{
    public interface IServiceTypeService
    {
        ServiceTypeModel GetById(int id);

        IList<ServiceTypeModel> GetAll();

        ResponseBase Insert(ServiceTypeModel serviceType);

        ResponseBase Update(ServiceTypeModel serviceType);

        ResponseBase Delete(long id);
    }
}
