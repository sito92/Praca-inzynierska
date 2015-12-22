using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MenuButton
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public virtual MenuButton Parent { get; set; }
        public int? PageId { get; set; }
        public virtual Page Page { get; set; }

        public virtual ICollection<MenuButton> Children { get; set; }
    }
}
