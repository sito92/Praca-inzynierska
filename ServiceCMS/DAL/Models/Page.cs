using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public IEnumerable<File> Media { get; set; }
        public DateTime? CreationTimeStamp { get; set; }
        public DateTime? LastModifiedTimeStamp { get; set; }

        public virtual Page RestorePage { get; set; }
        public int? RestorePageId { get; set; }
    }
}
