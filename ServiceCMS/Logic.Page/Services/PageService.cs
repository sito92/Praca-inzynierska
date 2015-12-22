using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using DAL.Repository;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Page.Interfaces;

namespace Logic.Page.Services
{
    public class PageService : IPageService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public PageService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }
        public PageModel GetById(int id)
        {
            PageModel pageModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.PageRepository.GetByID(id);
                    if (entity != null)
                    {
                        pageModel = new PageModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return pageModel;
        }

        public IList<PageModel> GetAll()
        {
            IList<PageModel> pageModels = new List<PageModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.PageRepository.Get();
                    foreach (var entity in entities)
                    {
                        pageModels.Add(new PageModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return pageModels;
        }

        public ResponseBase Insert(PageModel page)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {

                    if (page != null)
                    {
                        page.CreationTimeStamp = DateTime.Now;
                        unitOfWork.PageRepository.Insert(page.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.SavePageSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.SavePageFailed };
                }
                return response;
            }
        }

        public ResponseBase Update(PageModel page)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (page != null)
                    {
                        var updatedPage = new PageModel()
                        {
                            Content = page.Content,
                            CreationTimeStamp = DateTime.Now,
                            LastModifiedTimeStamp = page.LastModifiedTimeStamp,
                            Media = page.Media,
                            Name = page.Name,
                            RestorePageId = page.Id
                        };
                        unitOfWork.PageRepository.Insert(updatedPage.ToEntity());
                    }

                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.ModifyPageSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.ModifyPageFailed };
                }
                return response;
            }
        }

        public IEnumerable<PageModel> GetRestorePagesCollection(PageModel page, bool rootPageExcluded = false)
        {
            var resultCollection = new List<PageModel>();
            Stack<PageModel> branchPages = new Stack<PageModel>();
            if (page != null)
            {
                var rootPage = page;
                branchPages.Push(rootPage);

                while (branchPages.Count > 0)
                {
                    using (var unitOfWork = _unitOfWorkFactory.Create())
                    {
                        var tempPage = branchPages.Pop();
                        resultCollection.Add(tempPage);
                        if (tempPage.RestorePageId != null)
                        {
                            var restorePage =
                                unitOfWork.PageRepository.Get(x => x.Id == tempPage.RestorePageId).Single();
                            if (restorePage != null)
                            {
                                branchPages.Push(new PageModel(restorePage));
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

        public IEnumerable<PageModel> GetNewestPagesCollection()
        {
            var resultCollection = new List<PageModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.PageRepository.Get().ToList();

                    foreach (var entity in entities)
                    {
                        var collectionOfNewerPages = entities.Where(x => x.RestorePageId == entity.Id);

                        if (collectionOfNewerPages.Count() == 0)
                            resultCollection.Add(new PageModel(entity));
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

        #region TODO
        //public IEnumerable<object> GetRestorePagesCollectionGeneric<T>(object entity, GenericRepository<T> repository)
        //    where T : class
        //{
        //    var resultCollection = new List<object>();
        //    Stack<object> branchPages = new Stack<object>();
        //    T restoreObj = null;

        //    if (entity != null)
        //    {
        //        var rootEntity = entity;
        //        branchPages.Push(rootEntity);

        //        while (branchPages.Count > 0)
        //        {
        //            var tempObj = branchPages.Pop();
        //            resultCollection.Add(tempObj);
        //            if (tempObj.GetType().GetProperty("RestorePageId").GetValue(tempObj, null) != null)
        //            {
        //                restoreObj =
        //                    repository.Get(
        //                        x =>
        //                            x.GetType().GetProperty("Id").GetValue(x, null) ==
        //                            tempObj.GetType().GetProperty("RestorePageId").GetValue(tempObj, null)).Single();
        //                if (restoreObj != null)
        //                {
        //                    resultCollection.Add(restoreObj);
        //                }
        //            }
        //        }

        //        return resultCollection;
        //    }
        //    return null;
        //}
        #endregion

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.PageRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.RemovePageSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.RemovePageFailed };
                }
            }
            return response;
        }
    }
}
