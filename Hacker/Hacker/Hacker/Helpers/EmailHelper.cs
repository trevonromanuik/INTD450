using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using SendGridMail;
using SendGridMail.Transport;

namespace Hacker.Helpers
{
    public static class EmailHelper
    {
        private static NetworkCredential credentials = new NetworkCredential("azure_07b430384d567c2b53e0bd0226b05bfc@azure.com", "zhzawmoz");
        private static MailAddress from = new MailAddress("ching.jordan@gmail.com");

        public static void sendMessage(string recipientAddress, string recipientName)
        {
            var message = SendGrid.GetInstance();
            message.AddTo(recipientAddress);
            message.From = from;
            message.Subject = "Welcome";
            message.Text = "Testing";
            var transportRest = Web.GetInstance(credentials);

            transportRest.Deliver(message);
        }
    }
}
