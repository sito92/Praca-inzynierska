using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }
        
        public UserModel Author { get; set; }
        public int AuthorId { get; set; }

        public DateTime? CreationTimeStamp { get; set; }
        public DateTime? LastModifiedTimeStamp { get; set; }

        public int? RestoreNewsId { get; set; }
        public NewsModel RestoreNews { get; set; }

        public ICollection<NewsCategoryModel> Categories { get; set; } 

        public NewsModel(News entity)
        {
            Id = entity.Id;
            Content = entity.Content;
            Title = entity.Title;
            CreationTimeStamp = entity.CreationTimeStamp;
            LastModifiedTimeStamp = entity.LastModifiedTimeStamp;
            RestoreNews = entity.RestoreNews == null ? null : new NewsModel(entity.RestoreNews);
            RestoreNewsId = entity.RestoreNewsId;
            Categories = entity.NewsCategories == null
                ? new List<NewsCategoryModel>()
                : entity.NewsCategories.Select(x => new NewsCategoryModel(x)).ToList();
        }

        public NewsModel()
        {

        }

        public News ToEntity()
        {
            return new News()
            {
                Id = this.Id,
                Content = this.Content,
                Title = this.Title,
                CreationTimeStamp = this.CreationTimeStamp,
                LastModifiedTimeStamp = this.LastModifiedTimeStamp,
                RestoreNews = this.RestoreNews == null ? null : this.RestoreNews.ToEntity(),
                RestoreNewsId = this.RestoreNewsId,
                NewsCategories = this.Categories == null ? new List<NewsCategory>() : this.Categories.Select(x=>x.ToEntity()).ToList() 
            };
        }
    }
}
