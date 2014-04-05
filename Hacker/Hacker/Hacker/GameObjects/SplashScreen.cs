using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class SplashScreen : GameObject
    {
        public SplashScreen()
        {
            AddComponent(new Position(320,350));
            AddComponent(new Sprite(AssetManager.LoadTexture("globecomm")));
        }
    }
}
