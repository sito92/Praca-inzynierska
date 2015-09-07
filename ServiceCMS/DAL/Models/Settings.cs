using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Settings
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string EmailPassword { get; set; }

        public string Salt { get; set; }
    }
}
