using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Layers;

namespace Hacker.Levels
{
    class InsideLevel : Level
    {
        public InsideLevel()
            : base()
        {
            PushLayer(new InsideMapLayer());
        }
    }
}
