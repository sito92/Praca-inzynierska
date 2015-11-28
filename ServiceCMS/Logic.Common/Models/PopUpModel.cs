using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class PopUpModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public PopUpModel(PopUp popUp)
        {
            Id = popUp.Id;
            Content = popUp.Content;
            Title = popUp.Title;
        }

        public PopUp ToEntity()
        {
            return new PopUp()
            {
                Id = this.Id,
                Content=this.Content,
                Title = this.Title
            };
        }
    }
}
