using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.GameObjects
{
    public class Trigger : GameObject
    {
        public Trigger(Rectangle rectangle, Action action)
        {
            AddComponent(new Position(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2));
            AddComponent(new Boundary(rectangle.Width, rectangle.Height));

            AddComponent(new TriggerCollision(action));
        }
    }
}
