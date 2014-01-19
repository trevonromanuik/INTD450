using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Screens;

namespace Hacker.Managers
{
    public class ScreenManager
    {
        private Screen _prevScreen;
        private Screen _screen;

        public void LoadNewScreen(Screen screen)
        {
            _prevScreen = _screen;
            if (_prevScreen != null)
                _prevScreen.Uninitialize();
            _screen = screen;
            _screen.Initialize();
            _screen.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            _screen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _screen.Draw(spriteBatch);
        }
    }
}
