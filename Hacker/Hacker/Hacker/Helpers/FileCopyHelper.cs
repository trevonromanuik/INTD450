using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;

using Hacker.Managers;
using HackerDataTypes;

namespace Hacker.Helpers
{
    public static class FileCopyHelper
    {
        private static string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string parentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

        public static void copyFile(string fileName, string subDir = "")
        {

            var destFilePath = dir + "/GlobeComm Deliveries/" + subDir + fileName;
            string sourceFilePath = Path.Combine(@"Content\MiscFiles\" + fileName);
            
            if (!Directory.Exists(dir + "/GlobeComm Deliveries/" + subDir))
                Directory.CreateDirectory(dir + "/GlobeComm Deliveries/" + subDir);

            System.IO.File.Copy(sourceFilePath, destFilePath, true);
            SoundManager.PlaySound("download", false);
        }

        public static void createShortcut(string shortcutName, string fileName)
        {
            string destPath = Path.Combine(@"Content", "MiscFiles");
            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);

            string shortcutLocation = System.IO.Path.Combine(destPath, shortcutName + ".lnk");
            string targetFileLocation = System.IO.Path.Combine(destPath, fileName);
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.TargetPath = System.IO.Path.GetFullPath(targetFileLocation); // The path of the file that will launch when the shortcut is run
            shortcut.Save();
        }
    }
}
