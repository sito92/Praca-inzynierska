using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;

namespace Logic.ContactForm.Interfaces
{
    public interface IContactFormService
    {
        ResponseBase Send(string authorEmailAddress, string topic, string content);
    }
}
