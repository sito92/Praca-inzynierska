using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int FileType { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
    }
}
