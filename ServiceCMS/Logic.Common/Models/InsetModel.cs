using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using DAL.Models;

namespace Logic.Common.Models
{
    public class InsetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LocalizedName
        {
            get
            {
                return Modules.Resources.Logic.ResourceManager.GetString(Name.UpperFirst());
            }
        }

        public ICollection<InsetArgumentModel> Arguments { get; set; }

        public InsetModel()
        {
            
        }
        public InsetModel(Inset entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Arguments = entity.Arguments.Select(x => new InsetArgumentModel(x)).ToList();
        }

        public Inset ToEntity()
        {
            return new Inset()
            {
                Id = this.Id,
                Name = this.Name,
                Arguments = this.Arguments.Select(x => x.ToEntity()).ToList()
            };
        }
    }
}
