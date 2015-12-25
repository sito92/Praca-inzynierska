using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Settings
    {
        [Key]
        public string Name { get; set; }

        public string Value { get; set; }

        public string InputType { get; set; }
    }
}
