using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.NewsCategory.Interfaces;

namespace Logic.NewsCategory.Services
{
    public class NewsCategoryService : INewsCategoryService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public NewsCategoryService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }

        public NewsCategoryModel GetById(int id)
        {
            NewsCategoryModel categoryModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.NewsCategoryRepository.GetByID(id);
                    if (entity != null)
                    {
                        categoryModel = new NewsCategoryModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
                return categoryModel;
            }
        }

        public IList<NewsCategoryModel> GetAll()
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
                return newsCategoryModels;
            }
        }

        public ResponseBase Insert(NewsCategoryModel newsCategory)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {

                    if (newsCategory != null)
                    {
                        unitOfWork.NewsCategoryRepository.Insert(newsCategory.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase(){IsSucceed = true, Message = Modules.Resources.Logic.NewsCategoryInsertSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsCategoryInsertFailed };
                }
                return response;
            }
        }

        public ResponseBase Update(NewsCategoryModel newsCategory)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (newsCategory != null)
                    {
                        unitOfWork.NewsCategoryRepository.Update(newsCategory.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase(){IsSucceed = true, Message = Modules.Resources.Logic.NewsCategoryUpdateSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsCategoryUpdateFailed };
                }
                return response;
            }
        }

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.NewsCategoryRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.NewsCategoryDeleteSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsCategoryDeleteFailed };
                }
            }
            return response;
        }
    }
}

