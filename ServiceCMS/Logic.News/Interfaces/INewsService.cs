﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.News.Interfaces
{
    public interface INewsService
    {
        NewsModel GetById(int id);

        IList<NewsModel> GetAll();

        ResponseBase Insert(NewsModel news);

        ResponseBase Update(NewsModel news);

        ResponseBase Delete(long id);
    }
}