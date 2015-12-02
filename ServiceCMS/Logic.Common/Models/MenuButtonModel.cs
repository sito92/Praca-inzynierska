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

        public MenuButton Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<MenuButton> Children { get; set; }

        public MenuButtonModel()
        {
        }

        public MenuButtonModel(MenuButton menuButton)
        {
            Id = menuButton.Id;
            Content = menuButton.Content;
            ParentId = menuButton.ParentId;
            Parent = menuButton.Parent;
            Children = menuButton.Children;
        }

        public MenuButton ToEntity()
        {
            return new MenuButton()
            {
                Id = this.Id,
                Content = this.Content,
                Parent = this.Parent,
                Children = this.Children,
                ParentId = this.ParentId
            };
        }
    }
}
