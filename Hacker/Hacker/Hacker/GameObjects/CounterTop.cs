using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class CounterTop : GameObject
    {
        public CounterTop(int left, int top, int rY)
        {
            var texture = AssetManager.LoadTexture("counter_top");

            AddComponent(new Position(
                left + (texture.Width) / 2,
                top + (texture.Height * rY) / 2
            ));
            AddComponent(new RepeatingSprite(texture, 1, rY));
        }
    }
}
