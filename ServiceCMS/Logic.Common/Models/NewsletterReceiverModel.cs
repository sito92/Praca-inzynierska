using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class NewsletterReceiverModel
    {
         public int Id { get; set; }

        public string EmailAddress { get; set; }

        public NewsletterReceiverModel()
        {
            
        }
        public NewsletterReceiverModel(NewsletterReceiver entity)
        {
            this.Id = entity.Id;
            this.EmailAddress = entity.EmailAddress;
        }

        public NewsletterReceiver ToEntity()
        {
            return new NewsletterReceiver()
            {
                Id = this.Id,
                EmailAddress = this.EmailAddress,
            };
        }
    }
}
