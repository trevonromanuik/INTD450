using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class GlassScreen : GameObject
    {
        public GlassScreen(int left, int top, int rX)
        {
            var texture = AssetManager.LoadTexture("glass");

            AddComponent(new Position(
                left + (texture.Width * rX) / 2,
                top + (texture.Height) / 2
            ));
            AddComponent(new RepeatingSprite(texture, rX, 1));
        }
    }
}
