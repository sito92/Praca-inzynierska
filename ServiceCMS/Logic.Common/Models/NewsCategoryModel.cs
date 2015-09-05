using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Common.Models
{
    public class NewsCategoryModel
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public NewsCategoryModel(NewsCategory entity)
        {
            this.Id = entity.Id;
            this.Category = entity.Category;
        }

        public NewsCategory ToEntity()
        {
            return new NewsCategory()
            {
                Id = this.Id,
                Category = this.Category
            };
        }
    }
}
