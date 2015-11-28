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
        ResponseBase Update(PopUpModel popUp);

        ResponseBase Insert(PopUpModel popUp);
    }
}
