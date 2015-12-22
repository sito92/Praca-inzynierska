using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Migrations;
using Logic.Common.Models;

namespace Logic.NewsletterReceiver.Interfaces
{
    public interface INewsletterReceiverService
    {
        NewsletterReceiverModel GetById(int id);

        IList<NewsletterReceiverModel> GetAll();

        ResponseBase Insert(NewsletterReceiverModel newsletterReceiver);

        ResponseBase Update(NewsletterReceiverModel newsletterReceiver);

        ResponseBase Delete(long id);
    }
}
