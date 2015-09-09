using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Inset.Interfaces;

namespace Logic.Inset.Services
{
    public class InsetService : IInsetService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public InsetService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }
        public InsetModel GetByName(string name)
        {
            InsetModel insetModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.InsetRepository.Get(x=>x.Name==name).FirstOrDefault();
                    if (entity != null)
                    {
                        insetModel = new InsetModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return insetModel;
        }
        public IList<InsetModel> GetAll()
        {
            IList<InsetModel> insetModels = new List<InsetModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.InsetRepository.Get();
                    foreach (var entity in entities)
                    {
                        insetModels.Add(new InsetModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return insetModels;
        }
    }
}
