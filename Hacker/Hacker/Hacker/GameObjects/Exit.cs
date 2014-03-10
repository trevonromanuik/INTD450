using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Extensions;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Exit<T> : GameObject where T : Level, new()
    {
        public Exit(Rectangle position, Vector2 newPlayerPosition)
        {
            AddComponent(new Position(position.X + position.Width / 2, position.Y + position.Height / 2));
            AddComponent(new Boundary(position.Width, position.Height));
            AddComponent(new LevelSwitchCollision<T>(newPlayerPosition));


        }
    }
}
