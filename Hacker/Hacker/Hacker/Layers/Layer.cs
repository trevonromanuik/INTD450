using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Levels;

namespace Hacker.Layers
{
    abstract class Layer
    {
        public Level Level { get; private set; }

        public void Initialize(Level level)
        {
            Level = level;
        }

        public abstract void LoadContent();

        public abstract void UnloadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
