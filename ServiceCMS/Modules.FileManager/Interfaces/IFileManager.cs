using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.FileManager.Interfaces
{
    public interface IFileManager
    {
        bool SaveFile(string filePath, string fileName, byte[] fileData);

        bool DeleteFile(string fullFilePath);

        bool DeleteFile(string filePath, string fileName);

        bool Exists(string filePath);

        byte[] GetFileData(string filePath);
    }
}
