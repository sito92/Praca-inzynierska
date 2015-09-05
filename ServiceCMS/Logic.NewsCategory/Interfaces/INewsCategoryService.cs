using System.Collections.Generic;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.NewsCategory.Interfaces
{
    public interface INewsCategoryService
    {
        NewsCategoryModel GetById(int id);

        IList<NewsCategoryModel> GetAll();

        ResponseBase Insert(NewsCategoryModel news);

        ResponseBase Update(NewsCategoryModel news);

        ResponseBase Delete(long id);
    }
}
