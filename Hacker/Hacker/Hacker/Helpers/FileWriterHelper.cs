using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hacker.Managers;

namespace Hacker.Helpers
{
    public static class FileWriterHelper
    {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();

        public static void writeFile(string fileName)
        {
            var message = AssetManager.LoadMessage("Messages/"+fileName);

            var fileLabel = CurrentDirectory + "/" + message.file_name;
            File.WriteAllText(fileLabel, message.body_text);
        }
    }
}
