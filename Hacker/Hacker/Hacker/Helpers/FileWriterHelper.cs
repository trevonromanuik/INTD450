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
        //private static string dir = Directory.GetCurrentDirectory();
        private static string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void writeFile(string fileName, string subDir = "")
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

            if (message != null)
            {
                if (!Directory.Exists(dir+"/GlobeComm Deliveries/" + subDir))
                    Directory.CreateDirectory(dir + "/GlobeComm Deliveries/" + subDir);

                var fileLabel = dir + "/GlobeComm Deliveries/" + subDir + message.file_name;
                string[] split = message.body_text.Split('\n');
                File.WriteAllLines(fileLabel, split);
                SoundManager.PlaySound("download", false);
            }
        }
    }
}
