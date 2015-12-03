using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Settings.Interfaces;

namespace Logic.Settings.Services
{
    public class SettingsService:ISettingsService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public SettingsService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }

        //public SettingsModel Get()
        //{
        //    SettingsModel settingsModel = null;
        //    using (var unitOfWork = _unitOfWorkFactory.Create())
        //    {
        //        try
        //        {
        //            var entity = unitOfWork.SettingsRepository.Get();
        //            if (entity != null)
        //            {
        //                settingsModel = new SettingsModel(entity.FirstOrDefault());
        //            }
        //            unitOfWork.Save();
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogToFile(_logger.CreateErrorMessage(e));
        //        }

        //        return settingsModel;
        //    }
        //}

        //public ResponseBase Update(SettingsModel settings)
        //{
        //    ResponseBase response;
        //    using (var unitOfWork = _unitOfWorkFactory.Create())
        //    {
        //        try
        //        {
        //            if (settings != null)
        //            {
        //                unitOfWork.SettingsRepository.Update(settings.ToEntity());
        //            }
        //            unitOfWork.Save();
        //            return new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.UpdateSettingsSuccess};
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogToFile(_logger.CreateErrorMessage(e));
        //            response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.UpdateSettingsFailed };
        //        }
        //    }
        //    return response;
        //}
    }
}
