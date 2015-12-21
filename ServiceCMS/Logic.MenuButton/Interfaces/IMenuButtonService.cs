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

        IList<MenuButtonModel> GetAllRootButtons();

        ResponseBase Insert(MenuButtonModel menuButton);

        ResponseBase Update(MenuButtonModel menuButton);

        ResponseBase Delete(long id);
    }
}
