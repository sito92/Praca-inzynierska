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
                Name = "link",
                Arguments = new List<InsetArgumentModel>()
                {
                    new InsetArgumentModel()
                    {
                        Name = "url",
                        Id=1,
                        IsRequierd = true,
                        Type = InsetArgumentTypeEnum.String
                    },
                    new InsetArgumentModel()
                    {
                        Name = "text",
                        Id =2,
                        IsRequierd = true,
                        Type = InsetArgumentTypeEnum.String
                    }
                }
            };
        }
    }
}
