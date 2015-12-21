using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class MenuButtonModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public MenuButtonModel Parent { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public ICollection<MenuButtonModel> Children { get; set; }

        public MenuButtonModel()
        {
        }

        public MenuButtonModel(MenuButton menuButton)
        {
            Id = menuButton.Id;
            Content = menuButton.Content;
            ParentId = menuButton.ParentId;
            //Parent = menuButton.Parent == null ? null : new MenuButtonModel(menuButton.Parent);
            Children = menuButton.Children == null ? null : menuButton.Children.Select(x=>new MenuButtonModel(x)).ToList();
        }

        public MenuButton ToEntity()
        {
            return new MenuButton()
            {
                Id = this.Id,
                Content = this.Content,
                //Parent = this.Parent == null ? null : this.Parent.ToEntity(),
                Children = this.Children == null ? null :this.Children.Select(x=>x.ToEntity()).ToList(),
                ParentId = this.ParentId
            };
        }
    }
}
