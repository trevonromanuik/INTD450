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
        public Exit(Vector2 position)
        {
            AddComponent(new Position(position.X, position.Y));
            AddComponent(new Sprite(AssetManager.LoadTexture("exit")));
            AddComponent(new LevelSwitchCollision<T>());
        }
    }
}
