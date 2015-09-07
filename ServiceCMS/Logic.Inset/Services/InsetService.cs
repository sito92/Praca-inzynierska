using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Logic.Common.Models;
using Logic.Inset.Interfaces;

namespace Logic.Inset.Services
{
    public class InsetService:IInsetService
    {
        public InsetModel GetByName(string name)
        {
            return new InsetModel()
            {
                Id = 1,
                Name = "user",
                Arguments = new List<InsetArgumentModel>()
                {
                    new InsetArgumentModel()
                    {
                        Name = "id",
                        Id=1,
                        IsRequierd = true,
                        Type = InsetArgumentTypeEnum.Number
                    }
                
                }
            };
        }
    }
}
