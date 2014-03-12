using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Levels;
using Hacker.Screens;

namespace Hacker.Transitions
{
    abstract class Transition
    {
        protected Level _oldLevel;
        protected Level _newLevel;

        public void Initialize(Level oldLevel, Level newLevel)
        {
            _oldLevel = oldLevel;
            _newLevel = newLevel;
        }

        protected void SwitchLevel()
        {
            GameScreen.LoadLevel(_newLevel);
        }

        protected void Done()
        {
            GameScreen.RemoveTransition();
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
