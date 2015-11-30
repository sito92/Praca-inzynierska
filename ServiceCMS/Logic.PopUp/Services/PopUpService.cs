using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.PopUp.Interfaces;

namespace Logic.PopUp.Services
{
    public class PopUpService : IPopUpService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public PopUpService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }


        public ResponseBase Update(PopUpModel popUp)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (popUp != null)
                    {
                        unitOfWork.PopUpRepository.Update(popUp.ToEntity());
                    }
                    unitOfWork.Save();
                    response=new ResponseBase(){IsSucceed = true,Message = Modules.Resources.Logic.PopUpModifySuccess};
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.PopUpModifyFailed };
                }
            }
            return response;
        }

        public ResponseBase Insert(PopUpModel popUp)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (popUp != null)
                    {
                        unitOfWork.PopUpRepository.Insert(popUp.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.PopUpModifySuccess};
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.PopUpInsertFailed };
                }
                return response;
            }
        }
    }
}
