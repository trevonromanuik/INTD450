using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Extensions;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Transitions;

namespace Hacker.Levels
{
    abstract class Level
    {
        Stack<Layer> layers;

        public Level()
        {
            layers = new Stack<Layer>();
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

        public T GetLayer<T>() where T : Layer
        {
            return (T)layers.FirstOrDefault(x => x.IsInstanceOf(typeof(T)));
        }
    }
}
