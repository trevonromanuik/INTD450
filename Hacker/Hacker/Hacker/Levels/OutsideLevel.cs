using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Layers;

namespace Hacker.Levels
{
    class OutsideLevel : Level
    {
        public OutsideLevel()
            : base()
        {
            PushLayer(new OutsideMapLayer());
        }
    }
}
