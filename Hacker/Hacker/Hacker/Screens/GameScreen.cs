using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Levels;
using Hacker.Managers;

namespace Hacker.Screens
{
    class GameScreen : Screen
    {
        Level level;

        public GameScreen(ScreenManager screenManager)
            : base(screenManager)
        {
            level = new Level();
        }

        public override void LoadContent()
        {
            level.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            level.Update(gameTime);   
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
        }
    }
}
