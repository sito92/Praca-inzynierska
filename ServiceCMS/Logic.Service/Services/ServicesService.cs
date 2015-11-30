﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Service.Interfaces;

namespace Logic.Service.Services
{
    public class ServicesService : IServicesService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public ServicesService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }
        public List<RegistratedServiceModel> GetAllFromDate(DateTime date)
        {
            List<RegistratedServiceModel> serviceModels = new List<RegistratedServiceModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.RegistratedServiceRepository.Get(x=>x.StartDate.Date == date.Date);
                    foreach (var entity in entities)
                    {
                        serviceModels.Add(new RegistratedServiceModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceModels;

        }
    }
}