using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.News.Interfaces;

namespace Logic.News.Services
{
    public class NewsService:INewsService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public NewsService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }

        public NewsModel GetById(int id)
        {
            NewsModel newsModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.NewsRepository.GetByID(id);
                    if (entity != null)
                    {
                        newsModel = new NewsModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return newsModel;
        }
     

        public IList<NewsModel> GetAll()
        {
            IList<NewsModel> newsModels = new List<NewsModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.NewsRepository.Get();
                    foreach (var entity in entities)
                    {
                        newsModels.Add(new NewsModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return newsModels;
        }
        public IList<NewsCategoryModel> GetAllCategories()
        {
            IList<NewsCategoryModel> newsCategoryModels = new List<NewsCategoryModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.NewsCategoryRepository.Get();
                    foreach (var entity in entities)
                    {
                        newsCategoryModels.Add(new NewsCategoryModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return newsCategoryModels;
        }

        public IEnumerable<NewsModel> GetNewestNewsesCollection()
        {
            var resultCollection = new List<NewsModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.NewsRepository.Get().ToList();

                    foreach (var entity in entities)
                    {
                        var collectionOfNewerNewses = entities.Where(x => x.RestoreNewsId == entity.Id);

                        if (collectionOfNewerNewses.Count() == 0)
                            resultCollection.Add(new NewsModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return resultCollection;
        }

        public ResponseBase Insert(NewsModel news)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (news != null)
                    {
                        news.CreationTimeStamp = DateTime.Now;
                        news.LastModifiedTimeStamp = DateTime.Now;
                        var entity = news.ToEntity();
                        UpdateCategories(entity,unitOfWork);
                        unitOfWork.NewsRepository.Insert(entity);
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.SaveNewsSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.SaveNewsFailed };
                }
                return response;
            }
        }

        public ResponseBase Update(NewsModel news)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (news != null)
                    {
                        var updatedNews = new NewsModel()
                        {
                            Content = news.Content,
                            CreationTimeStamp = news.CreationTimeStamp,
                            LastModifiedTimeStamp = DateTime.Now,
                            Title = news.Title,
                            RestoreNewsId = news.Id,
                            AuthorId = news.AuthorId,
                            Categories = news.Categories
                        
                        };
                        var entity=updatedNews.ToEntity();
                        unitOfWork.NewsRepository.Insert(entity);
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.ModifyNewsSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.ModifyNewsFailed };
                }
            }
            return response;
        }

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.NewsRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.RemoveNewsSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.RemoveNewsFailed };
                }
            }
            return response;
        }

        public IEnumerable<NewsModel> GetRestoreNewsesCollection(NewsModel news, bool rootPageExcluded = false)
        {
            var resultCollection = new List<NewsModel>();
            Stack<NewsModel> branchNewses = new Stack<NewsModel>();
            if (news != null)
            {
                var rootNews = news;
                branchNewses.Push(rootNews);

                while (branchNewses.Count > 0)
                {
                    using (var unitOfWork = _unitOfWorkFactory.Create())
                    {
                        var tempNews = branchNewses.Pop();
                        resultCollection.Add(tempNews);
                        if (tempNews.RestoreNewsId != null)
                        {
                            var restoreNews =
                                unitOfWork.NewsRepository.Get(x => x.Id == tempNews.RestoreNewsId).Single();
                            if (restoreNews != null)
                            {
                                branchNewses.Push(new NewsModel(restoreNews));
                            }
                        }
                    }
                }
                if (rootPageExcluded)
                    resultCollection.RemoveAt(0);

                return resultCollection;
            }
            return null;
        }
        public void UpdateCategories(DAL.Models.News entity, IUnitOfWork unitOfWork)
        {
            var ids = entity.NewsCategories.Select(x => x.Id);
            var categories = unitOfWork.NewsCategoryRepository.Get(x => ids.Contains(x.Id));
            var entityFromBase = unitOfWork.NewsRepository.Get(x => x.Id == entity.Id).SingleOrDefault();

            if (entityFromBase != null)
            {
                entityFromBase.NewsCategories.Clear();
                entity = entityFromBase;
            }


            entity.NewsCategories.Clear();

            foreach (var category in categories)
            {
                entity.NewsCategories.Add(category);
            }
        }
    }
}
