using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int AuthorId { get; set; }

        #region Navigation Properties
        public User Author { get; set; }
        public NewsCategory NewsCategory { get; set; }
        #endregion
    }
}
