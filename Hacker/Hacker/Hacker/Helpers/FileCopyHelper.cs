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

        public static void copyFile(string fileName, string subDir = "")
        {
            string parentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string sourceFilePath = Path.Combine(parentDir, @"HackerContent\MiscFiles\", fileName);
            var destFilePath = dir + "/GlobeComm Deliveries/" + subDir + fileName;

            if (!Directory.Exists(dir + "/GlobeComm Deliveries/" + subDir))
                Directory.CreateDirectory(dir + "/GlobeComm Deliveries/" + subDir);

            File.Copy(sourceFilePath, destFilePath, true);
        }
    }
}
