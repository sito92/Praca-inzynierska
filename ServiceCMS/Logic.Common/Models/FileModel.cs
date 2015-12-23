using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL.Models;

namespace Logic.Common.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public FileTypeEnum FileType { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public FileModel()
        {
            
        }

        public FileModel(File file)
        {
            Id = file.Id;
            Path = file.Path;
            FileType = (FileTypeEnum) file.FileType;
            Extension = file.Extension;
            Name = file.Name;
            Size = file.Size;
        }

        public File ToEntity()
        {
            return new File()
            {
                Id = this.Id,
                Path = this.Path,
                FileType = (int) this.FileType,
                Extension = this.Extension,
                Name = this.Name,
                Size = this.Size
            };
        }
    }
}
