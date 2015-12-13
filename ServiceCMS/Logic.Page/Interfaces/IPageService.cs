using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.Page.Interfaces
{
    public interface IPageService
    {
        IEnumerable<PageModel> GetRestorePagesCollection(PageModel page, bool rootPageExcluded = false);
        //IEnumerable<object> GetRestorePagesCollectionGeneric<T>(object entity, GenericRepository<T> repository) where T:class;
        
        PageModel GetById(int id);

        IList<PageModel> GetAll();

        ResponseBase Insert(PageModel page);

        ResponseBase Update(PageModel page);

        ResponseBase Delete(long id);

        //ResponseBase Restore(PageModel page);
    }
}
