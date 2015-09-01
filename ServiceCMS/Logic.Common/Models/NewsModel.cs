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

        public DateTime Date { get; set; }


        public NewsModel(News entity)
        {
            Id = entity.Id;
            Content = entity.Content;
            Title = entity.Title;
            Author = entity.Author == null ? null : new UserModel(entity.Author);
        }

        public News ToEntity()
        {
            return new News()
            {
                Id = this.Id,
                Author = this.Author.ToEntity(),
                AuthorId = this.Author.Id,
                Content = this.Content,
                Title = this.Title,
                Date = this.Date
            };
        }
    }
}
