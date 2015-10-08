using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.File.Interfaces;

namespace Logic.File.Services
{
    public class FileService : IFileService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public FileService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }
        public IList<FileModel> GetAllImages()
        {
            IList<FileModel> fileModels = new List<FileModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.FileRepository.Get(x=>x.FileType == (int)FileTypeEnum.Image);
                    foreach (var entity in entities)
                    {
                        fileModels.Add(new FileModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return fileModels;
        }
    }
}
