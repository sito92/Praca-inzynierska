using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.MenuButton.Interfaces
{
    public interface IMenuButtonService
    {
        MenuButtonModel GetById(int id);

        IList<MenuButtonModel> GetAll();

        ResponseBase Insert(MenuButtonModel news);

        ResponseBase Update(MenuButtonModel news);

        ResponseBase Delete(long id);
    }
}
