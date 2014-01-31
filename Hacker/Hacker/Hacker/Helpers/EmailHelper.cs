using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using SendGridMail;
using SendGridMail.Transport;

using Hacker.Managers;

namespace Hacker.Helpers
{
    public static class EmailHelper
    {
        private static NetworkCredential credentials = new NetworkCredential("azure_07b430384d567c2b53e0bd0226b05bfc@azure.com", "zhzawmoz");

        public static void sendMessage(string name)
        {
            var email = AssetManager.LoadEmail("opening_email");
            var message = SendGrid.GetInstance();
            message.AddTo(email.to);
            message.From = new MailAddress(email.from);
            message.Subject = email.subject;
            message.Text = email.message;
            var transportRest = Web.GetInstance(credentials);

            transportRest.Deliver(message);
        }
    }
}
