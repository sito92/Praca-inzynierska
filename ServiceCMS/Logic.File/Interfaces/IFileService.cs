using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common.Enums;
using Common.Responses;
using DAL.Models;
using Logic.Common.Models;

namespace Logic.File.Interfaces
{
    public interface IFileService
    {
        IList<FileModel> GetAllFiles(FileTypeEnum enumValue);

        IList<FileModel> GetAllFiles();

        ResponseBase Insert(FileModel file);

        ResponseBase Update(FileModel file);

        ResponseBase UploadWithInsert(HttpPostedFileBase file,string name);

        ResponseBase Delete(int id);

        //void DownloadFile(FileModel file);
    }
}
