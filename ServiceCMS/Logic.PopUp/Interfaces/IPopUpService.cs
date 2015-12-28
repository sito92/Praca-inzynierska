using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.PopUp.Interfaces
{
    public interface IPopUpService
    {
        ResponseBase Delete(int id);

        ResponseBase Update(PopUpModel popUp);

        ResponseBase Update(IList<PopUpModel> popUps);

        ResponseBase Insert(PopUpModel popUp);

        IList<PopUpModel> GetAll();

        PopUpModel GetActivePopUp();
    }
}
