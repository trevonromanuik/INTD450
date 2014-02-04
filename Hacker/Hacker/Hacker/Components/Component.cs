using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.GameObjects;

namespace Hacker.Components
{
    public abstract class Component
    {
        public GameObject Owner { get; private set; }

        public void Initialize(GameObject gameObject)
        {
            Owner = gameObject;
        }

        public void Remove()
        {
            Owner.RemoveComponent(this);
        }

        public T GetComponent<T>() where T : Component
        {
            return Owner == null ? null : Owner.GetComponent<T>();
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
