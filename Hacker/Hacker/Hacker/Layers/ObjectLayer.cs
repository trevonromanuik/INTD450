using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Managers;

namespace Hacker.Layers
{
    class ObjectLayer : Layer
    {
        public GameObjectManager GameObjectManager { get; private set; }

        public ObjectLayer()
        {
            GameObjectManager = new GameObjectManager();
        }

        public override void Update(GameTime gameTime)
        {
            GameObjectManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            GameObjectManager.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
