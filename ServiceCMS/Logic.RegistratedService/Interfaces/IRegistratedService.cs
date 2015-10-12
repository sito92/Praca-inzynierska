using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;

namespace Logic.RegistratedService.Interfaces
{
    public interface IRegistratedService
    {
        Regis GetById(int id);

        IList<NewsModel> GetAll();

        ResponseBase Insert(NewsModel news);

        ResponseBase Update(NewsModel news);

        ResponseBase Delete(long id);
    }
}
