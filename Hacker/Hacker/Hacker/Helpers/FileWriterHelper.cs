using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hacker.Managers;
using HackerDataTypes;

namespace Hacker.Helpers
{
    public static class FileWriterHelper
    {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();

        public static void writeFile(string fileName)
        {
            Message message = null;

            try
            {
                message = AssetManager.LoadMessage("Messages/" + fileName);
            }
            catch (Microsoft.Xna.Framework.Content.ContentLoadException e)
            {
                Console.WriteLine(e.Message);
            }

            if(message != null)
            {
                var fileLabel = CurrentDirectory + "/" + message.file_name;
                File.WriteAllText(fileLabel, message.body_text);
            }
        }
    }
}
