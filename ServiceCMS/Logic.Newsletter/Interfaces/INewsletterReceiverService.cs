using Common.Responses;
using DAL.Models;
using Logic.Common.Models;

namespace Logic.Newsletter.Interfaces
{
    public interface INewsletterReceiverService
    {
        ResponseBase Insert(NewsletterReceiverModel newsletterReceiver);

        //brak update, bo chyba się nie da ;)

        ResponseBase Delete(long id);

        ResponseBase Send(string topic, string content);
    }
}
