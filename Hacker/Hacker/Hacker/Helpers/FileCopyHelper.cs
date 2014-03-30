using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string sourceFilePath = Path.Combine(parentDir, @"HackerContent\MiscFiles\", fileName);
            var destFilePath = dir + "/GlobeComm Deliveries/" + subDir + fileName;

            if (!Directory.Exists(dir + "/GlobeComm Deliveries/" + subDir))
                Directory.CreateDirectory(dir + "/GlobeComm Deliveries/" + subDir);

            System.IO.File.Copy(sourceFilePath, destFilePath, true);
            SoundManager.PlaySound("download", false);
        }

        public static void createShortcut(string shortcutName, string fileName)
        {
            string destPath = System.IO.Path.Combine(parentDir, "HackerContent", "MiscFiles");
            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);

            string shortcutLocation = System.IO.Path.Combine(destPath, shortcutName + ".lnk");
            string targetFileLocation = System.IO.Path.Combine(destPath, fileName);
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            //shortcut.Description = "My shortcut description";   // The description of the shortcut
            //shortcut.IconLocation = @"c:\myicon.ico";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;           // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
            SoundManager.PlaySound("download", false);
        }
    }
}
