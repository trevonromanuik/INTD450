using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hacker.Managers;

namespace Hacker.Extensions
{
    public class FileWriterExtension
    {
        private static string CurrentDirectory;

        static FileWriterExtension() 
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
        }
        
        public void writeFile(string fileName)
        {
            //var content = AssetManager.LoadXml(fileName);

            var message = "Some Content";// content.GetElementsByTagName("Message");
            var fileLabel = CurrentDirectory + "/" + "Test";//content.GetElementsByTagName("FileName");
            Console.WriteLine(CurrentDirectory);
            File.WriteAllText(fileLabel, message);//[0].ToString());
        }
    }
}
