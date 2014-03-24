using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using SendGridMail;
using SendGridMail.Transport;

using Hacker.Managers;
using Hacker.GameObjects;

namespace Hacker.Helpers
{
    public static class EmailHelper
    {
        // If you want to debug with a specific address, just hard-code this variable.
        private static string playerEmail;
        private static NetworkCredential credentials = new NetworkCredential("azure_07b430384d567c2b53e0bd0226b05bfc@azure.com", "zhzawmoz");

        public static void SendMessage(string name)
        {
            if (playerEmail == null)
            {
                playerEmail = Player.Instance.GetStringVariable("Email");
            }

            var email = AssetManager.LoadEmail(name);
            var message = SendGrid.GetInstance();
            message.AddTo(playerEmail);
            message.From = new MailAddress(email.from);
            message.Subject = email.subject;
            message.Text = email.message;
            var transportRest = Web.GetInstance(credentials);

            transportRest.DeliverAsync(message);
        }
    }
}
