using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Components
{ 
    class Keyloggable : Component
    {
        public string KeyLogPath { get; set; }

        public Keyloggable(string path)
        {
            KeyLogPath = path;
        }
    }
}
