using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Logic.Settings.Interfaces;

namespace Logic.Settings.Services
{
    public class SmtpClientDataRetrieval
    {
        private ISettingsService _settings;

        public SmtpClientDataRetrieval(ISettingsService settings)
        {
            _settings = settings;
        }

        public SmtpClient ConfigureClient()
        {
            var set = _settings.Get();

            var selectedEmailSettings =
                set.DomainAndPorts.FirstOrDefault(x => x.DomainName.Contains(set.EmailDomain));

            var client = new SmtpClient()
            {
                Host = selectedEmailSettings.DomainName,
                Port = selectedEmailSettings.DomainPort,
                Credentials = new NetworkCredential(set.EmailAddress, set.EmailPassword)
            };

            return client;
        }
    }
}
