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
        private static string playerEmail = null; // "teri@ualberta.ca";
        private static NetworkCredential credentials = new NetworkCredential("azure_07b430384d567c2b53e0bd0226b05bfc@azure.com", "zhzawmoz");

        public static bool SendMessage(string name)
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

            if (ConnectionMonitor.checkInterwebs())
            {
                transportRest.DeliverAsync(message);
                SoundManager.PlaySound("notification", false);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
