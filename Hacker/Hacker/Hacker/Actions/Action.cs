using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.GameObjects;

namespace Hacker.Actions
{
    public abstract class Action
    {
        public GameObject Owner { get; private set; }
        public bool Done { get; protected set; }

        public virtual void Initialize(GameObject owner)
        {
            Owner = owner;
        }

        public abstract void Update(GameTime gameTime);
    }
}
