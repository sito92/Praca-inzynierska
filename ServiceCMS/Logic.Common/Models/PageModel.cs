using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public ICollection<FileModel> Media { get; set; }
        public DateTime? CreationTimeStamp { get; set; }
        public DateTime? LastModifiedTimeStamp { get; set; }

        public int? RestorePageId { get; set; }
        public PageModel RestorePage { get; set; }

        public PageModel()
        {
        }

        public PageModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
            Content = page.Content;
            Media = page.Media == null
                ? new List<FileModel>()
                : page.Media.Select(x => new FileModel(x)).ToList(); ;
            CreationTimeStamp = page.CreationTimeStamp;
            LastModifiedTimeStamp = page.LastModifiedTimeStamp;
            RestorePage = page.RestorePage == null ? null : new PageModel(page.RestorePage);
            RestorePageId = page.RestorePageId;
        }

        public Page  ToEntity()
        {
            return new Page()
            {
                Id = this.Id,
                Name = this.Name,
                Content=this.Content,
                CreationTimeStamp = this.CreationTimeStamp,
                LastModifiedTimeStamp = this.LastModifiedTimeStamp,
                RestorePage = this.RestorePage == null ? null : this.RestorePage.ToEntity(),
                RestorePageId = this.RestorePageId,
                Media = this.Media == null ? new List<File>() : this.Media.Select(x => x.ToEntity()).ToList() 
            };
        }
    }
}
