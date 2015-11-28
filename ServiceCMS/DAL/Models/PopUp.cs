using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PopUp
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool Active { get; set; }

        //public File Image { get; set; }
    }
}
