using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientPanel.Helpers
{
    public static class ClientAddressEmailHelper
    {
        public static string RefactorClientAddress(string address)
        {
            return "<br><br> Wysłane przez: " + address;
        }
    }
}