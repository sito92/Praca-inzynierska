using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.NewsletterReceiver.Interfaces;

namespace Logic.NewsletterReceiver.Services
{
    public class NewsletterReceiverService : INewsletterReceiverService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public NewsletterReceiverService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }

        public NewsletterReceiverModel GetById(int id)
        {
            NewsletterReceiverModel newsletterReceiverModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.NewsletterReceiverRepository.GetByID(id);
                    if (entity != null)
                    {
                        newsletterReceiverModel = new NewsletterReceiverModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return newsletterReceiverModel;
        }

        public IList<NewsletterReceiverModel> GetAll()
        {
            IList<NewsletterReceiverModel> newsletterReceiverModels = new List<NewsletterReceiverModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.NewsletterReceiverRepository.Get();
                    foreach (var entity in entities)
                    {
                        newsletterReceiverModels.Add(new NewsletterReceiverModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return newsletterReceiverModels;
        }

        public ResponseBase Insert(NewsletterReceiverModel newsletterReceiver)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (newsletterReceiver != null)
                    {
                        unitOfWork.NewsletterReceiverRepository.Insert(newsletterReceiver.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.NewsletterReceiverInsertSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsletterReceiverInsertFailed };
                }
                return response;
            }
        }

        public ResponseBase Update(NewsletterReceiverModel newsletterReceiver)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (newsletterReceiver != null)
                    {
                        unitOfWork.NewsletterReceiverRepository.Update(newsletterReceiver.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.NewsletterReceiverUpdateSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsletterReceiverUpdateFailed };
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
                    if (id != 0)
                    {
                        unitOfWork.NewsletterReceiverRepository.Delete(id);
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.NewsletterReceiverDeleteSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsletterReceiverDeleteFailed };
                }
                return response;
            }
        }
    }
}
