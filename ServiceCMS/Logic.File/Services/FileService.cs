using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Common.Responses;
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
        
        public IList<FileModel> GetAllFiles(FileTypeEnum enumValue)
        {

            IList<FileModel> fileModels = new List<FileModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.FileRepository.Get(x => x.FileType == (int)enumValue);
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

        public ResponseBase Insert(FileModel file)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if(file != null)
                        unitOfWork.FileRepository.Insert(file.ToEntity());
                    
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.FileInsertSuccess};
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() {IsSucceed = false, Message = Modules.Resources.Logic.FileInsertFailed};
                }
            }
            return response;
        }

        public ResponseBase Update(FileModel file)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if(file != null)
                        unitOfWork.FileRepository.Update(file.ToEntity());
                    
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.FileUpdateSuccess};
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() {IsSucceed = false, Message = Modules.Resources.Logic.FileUpdateFailed};
                }
            }
            return response;
        }

        public ResponseBase Delete(int id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.FileRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.FileDeleteSuccess};
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() {IsSucceed = false, Message = Modules.Resources.Logic.FileDeleteFailed};
                }
            }
            return response;
        }
    }
}
