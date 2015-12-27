﻿using System;
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

        public Dictionary<string, Tuple<object,string>> GetAll()
        {
            Dictionary<string, Tuple<object, string>> result = new Dictionary<string, Tuple<object, string>>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.SettingsRepository.Get();
                    foreach (var setting in entities)
                    {
                        result.Add(setting.Name, new Tuple<object, string>(GetBoxedType(setting.Value,setting.InputType), setting.InputType));
                    }
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return result;
        }

        public string GetPropertyByName(string name)
        {
            string valueOfProperty = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.SettingsRepository.Get(x => x.Name == name).Single();
                    valueOfProperty = entity.Value;
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return valueOfProperty;
        }

        public ResponseBase Update(Dictionary<string, string> settingsDictionary)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    foreach (var settingsProperty in settingsDictionary.Keys)
                    {
                        var previousPropertyValue = unitOfWork.SettingsRepository.Get(x => x.Name == settingsProperty).FirstOrDefault();
                        previousPropertyValue.Value = settingsDictionary[settingsProperty];
                        unitOfWork.Save();
                    }

                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.SettingsUpdateSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.SettingsUpdateFailed };
                }
            }
            return response;
        }

        private object GetBoxedType(string value, string inputType)
        {
            try
            {
                switch (inputType)
                {
                    case "radio":

                        return Convert.ToBoolean(value);
                        break;
                    case "number":
                        return Convert.ToInt32(value);
                        break;
                    default:
                        return value;
                        break;
                        ;
                }
            }
            catch (Exception)
            {

                return value;
            }
          
        }
    }
}
