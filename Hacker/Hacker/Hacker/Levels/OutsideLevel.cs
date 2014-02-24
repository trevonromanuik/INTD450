using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;

namespace Hacker.Levels
{
    class OutsideLevel : Level
    {
        public OutsideLevel()
            : base()
        {
            PushLayer(new OutsideMapLayer());
            CameraManager.CameraTarget = Player.Instance;
        }

        public override void OnLoad()
        {
            SoundManager.PlayMusic("dance");
        }
    }
}
