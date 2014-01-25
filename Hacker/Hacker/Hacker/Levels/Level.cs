using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Layers;
using Hacker.Managers;

namespace Hacker.Levels
{
    class Level
    {
        Stack<Layer> layers;

        public Level()
        {
            layers = new Stack<Layer>();
            PushLayer(MapLayer.Instance);
        }

        public void LoadContent()
        {
            
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            layers.Peek().Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Layer layer in layers.Reverse())
            {
                layer.Draw(spriteBatch);
            }
        }

        public void PushLayer(Layer layer)
        {
            layer.Initialize(this);
            layers.Push(layer);
        }

        public void PopLayer()
        {
            Layer layer = layers.Pop();
            layer.UnloadContent();
        }
    }
}
