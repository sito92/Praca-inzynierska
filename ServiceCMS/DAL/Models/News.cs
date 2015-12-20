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

        public DateTime? CreationTimeStamp { get; set; }
        public DateTime? LastModifiedTimeStamp { get; set; }

        public int? RestoreNewsId { get; set; }


        #region Navigation Properties
        public virtual News RestoreNews { get; set; }
        public virtual ICollection<NewsCategory> NewsCategories { get; set; }
        #endregion
    }
}
