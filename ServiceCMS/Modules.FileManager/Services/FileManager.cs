using Common.Responses;
using Logging.Interfaces;
using Modules.FileManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.FileManager.Services
{
    public class FileManager : IFileManager
    {
        private readonly ILogger _logger;
   
        public FileManager(ILogger logger)
        {
            _logger = logger;
        }

        public bool SaveFile(string filePath, string fileName, byte[] fileData)
        {
            if (fileData.Length > 0)
            {
                try
                {
                    var path = Path.Combine(filePath, fileName);

                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);

                    if (File.Exists(path))
                        return false;

                    using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        fileStream.Write(fileData, 0, fileData.Length);
                        fileStream.Close();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool SaveFile(string filePath, byte[] fileData)
        {
            if (fileData.Length > 0)
            {
                try
                {
                    var directory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    if (File.Exists(filePath))
                        return false;

                    using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        fileStream.Write(fileData, 0, fileData.Length);
                        fileStream.Close();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool DeleteFile(string fullFilePath)
        {
            try
            {
                File.Delete(fullFilePath);
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
                return false;
            }
            return true;
        }

        public bool DeleteFile(string filePath, string fileName)
        {
            try
            {
                var path = Path.Combine(filePath, fileName);

                File.Delete(path);
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
                return false;
            }
            return true;
        }

        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public byte[] GetFileData(string filePath)
        {
            byte[] data = null;
            try
            {
                data = File.ReadAllBytes(filePath);
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
            }

            return data;
        }
    }
}
