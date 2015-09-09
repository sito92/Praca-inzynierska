using Common.Enums;
using DAL.Models;

namespace Logic.Common.Models
{
    public class InsetArgumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequierd { get; set; }
        public InsetArgumentTypeEnum Type { get; set; }

        public InsetArgumentModel()
        {
            
        }
        public InsetArgumentModel(InsetArgument entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            IsRequierd = entity.IsRequierd;
            Type = (InsetArgumentTypeEnum) entity.ArgumentType;
        }

        public InsetArgument ToEntity()
        {
            return new InsetArgument()
            {
                Id = this.Id,
                Name = this.Name,
                IsRequierd = this.IsRequierd,
                ArgumentType = (byte)this.Type
            };
        }
    }
}
