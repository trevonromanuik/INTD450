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
    class Spoofie : GameObject
    {
        public Spoofie()
        {
            Id = "spoofie";

            AddComponent(new Position(140, 60));

            Sprite sprite = new Sprite(AssetManager.LoadTexture("spoofie"));
            AddComponent(sprite);
        }
    }
}
