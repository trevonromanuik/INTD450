using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;

namespace Hacker.Levels
{
    class InsideLevel : Level
    {
        public InsideLevel()
            : base()
        {
            PushLayer(new InsideMapLayer());
        }

        public override void OnLoad()
        {
            //SoundManager.PlayMusic("dance");
        }
    }
}
