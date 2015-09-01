using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public UserModel(User entity)
        {            
        }

        public User ToEntity()
        {
            return new User();
        }
    }
}
