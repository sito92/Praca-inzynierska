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

        public PageModel()
        {
        }

        public PageModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
        }

        public Page  ToEntitiy()
        {
            return new Page()
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
