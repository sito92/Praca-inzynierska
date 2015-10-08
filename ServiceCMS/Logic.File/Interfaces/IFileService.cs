using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Logic.Common.Models;

namespace Logic.File.Interfaces
{
    public interface IFileService
    {
        IList<FileModel> GetAllImages();
    }
}
