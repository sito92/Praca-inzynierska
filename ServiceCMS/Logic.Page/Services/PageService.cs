using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Page.Interfaces;

namespace Logic.Page.Services
{
    public class PageService:IPageService
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
                        unitOfWork.PageRepository.Insert(page.ToEntitiy());
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
                        unitOfWork.PageRepository.Update(page.ToEntitiy());
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
