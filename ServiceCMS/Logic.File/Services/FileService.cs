using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common.Enums;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.File.Interfaces;
using Modules.FileManager.Interfaces;

namespace Logic.File.Services
{
    public class FileService : IFileService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;
        private IFileManager _fileManager;

        public FileService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger, IFileManager fileManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
            _fileManager = fileManager;
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
        public IList<FileModel> GetAllFiles()
        {

            IList<FileModel> fileModels = new List<FileModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.FileRepository.Get();
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
        public FileModel GetById(int id)
        {

            FileModel fileModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.FileRepository.Get(x => x.Id == id).FirstOrDefault();
                
                        fileModel  = new FileModel(entity);

                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return fileModel;
        }

        public ResponseBase Insert(FileModel file)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (file != null)
                        unitOfWork.FileRepository.Insert(file.ToEntity());

                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.FileInsertSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.FileInsertFailed };
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
                    if (file != null)
                        unitOfWork.FileRepository.Update(file.ToEntity());

                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.FileUpdateSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.FileUpdateFailed };
                }
            }
            return response;
        }
        public ResponseBase UploadWithInsert(HttpPostedFileBase file, string name)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (file != null)
                    {
                        var fileData = GetFileData(file);
                        var filePath = GetFilePath(file);
                        if (!_fileManager.SaveFile(filePath, fileData))
                        {
                            return new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.FileUpdateFailed };
                        }
                        FileModel model = new FileModel()
                        {
                            Name = name,
                            Path = filePath,
                            FileType = GetFileType(file),
                            Extension = Path.GetExtension(file.FileName),
                            Size = file.ContentLength

                        };
                        unitOfWork.FileRepository.Insert(model.ToEntity());
                    }

                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.FileUpdateSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.FileUpdateFailed };
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
                    var fileEntity = unitOfWork.FileRepository.Get(x => x.Id==id).FirstOrDefault();
                    if (fileEntity != null)
                    {
                        if (!_fileManager.DeleteFile(fileEntity.Path))
                        {
                            return new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.FileDeleteFailed };
                        }
                        unitOfWork.FileRepository.Delete(id);
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.FileDeleteSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.FileDeleteFailed };
                }
            }
            return response;
        }

        private byte[] GetFileData(HttpPostedFileBase file)
        {
            MemoryStream stream = new MemoryStream();
            file.InputStream.CopyTo(stream);
            return stream.ToArray();
        }

        private string GetFilePath(HttpPostedFileBase file)
        {
            var rootFolder = ConfigurationManager.AppSettings["rootFolder"];
            var filesFolder = ConfigurationManager.AppSettings["filesFolder"];
            var fileName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            return Path.Combine(rootFolder, filesFolder, fileName);
        }

        private FileTypeEnum GetFileType(HttpPostedFileBase file)
        {
            switch (file.ContentType)
            {
                case "image/jpeg":
                    return FileTypeEnum.Image;
                    break;
                default:
                    return FileTypeEnum.Other;
                    break;

            }
        }
    }
}
