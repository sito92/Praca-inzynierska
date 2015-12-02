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
        public IEnumerable<File> Media { get; set; }
        public DateTime? CreationTimeStamp { get; set; }
        public DateTime? LastModifiedTimeStamp { get; set; }

        public int? RestorePageId { get; set; }
        public Page RestorePage { get; set; }

        public PageModel()
        {
        }

        public PageModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
            Content = page.Content;
            Media = page.Media;
            CreationTimeStamp = page.CreationTimeStamp;
            LastModifiedTimeStamp = page.LastModifiedTimeStamp;
            RestorePage = page.RestorePage;
            RestorePageId = page.RestorePageId;
        }

        public Page  ToEntitiy()
        {
            return new Page()
            {
                Id = this.Id,
                Name = this.Name,
                Content=this.Content,
                CreationTimeStamp = this.CreationTimeStamp,
                LastModifiedTimeStamp = this.LastModifiedTimeStamp,
                RestorePage = this.RestorePage,
                RestorePageId = this.RestorePageId,
                Media = this.Media
            };
        }
    }
}
