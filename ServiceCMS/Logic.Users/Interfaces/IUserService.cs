using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.User.Interfaces
{
    public interface IUserService
    {
        UserModel GetById(int id);

        UserModel GetByLogin(string login);

        IList<UserModel> GetAll();

        ResponseBase Insert(UserModel user);

        ResponseBase Update(UserModel user);

        ResponseBase Delete(long id);
    }
}
