using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class InsetArgument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequierd { get; set; }
        public byte ArgumentType { get; set; }

    }
}
