using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.Page.Interfaces
{
    public interface IPageService
    {
        PageModel GetById(int id);

        IList<PageModel> GetAll();

        ResponseBase Insert(PageModel page);

        ResponseBase Update(PageModel page);

        ResponseBase Delete(long id);

        //ResponseBase Restore(PageModel page);
    }
}
