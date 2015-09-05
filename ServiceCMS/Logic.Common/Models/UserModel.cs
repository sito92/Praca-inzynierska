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
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public UserModel(User entity)
        {
            Id = entity.Id;
            Login = entity.Login;
            Password = entity.Password;
            Salt = entity.Salt;
        }

        public User ToEntity()
        {
            return new User()
            {
                Id = this.Id,
                Login = this.Login,
                Password = this.Password,
                Salt = this.Salt
            };
        }
    }
}
