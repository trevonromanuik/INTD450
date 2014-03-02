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
using Hacker.Transitions;

namespace Hacker.Screens
{
    class GameScreen : Screen
    {
        public static Level Level { get; private set; }
        static Transition _transition;

        public GameScreen(ScreenManager screenManager)
            : base(screenManager)
        {
            //LoadLevel<DataBankLevel>();
            LoadLevel<OutsideLevel>();
        }

        public static void LoadLevel(Level level)
        {
            _transition = null;
            Level = level;
        }

        public static void LoadLevel<T>() where T : Level, new()
        {
            Level = new T();
            Level.OnLoad();
        }

        public static void LoadLevel<T>(Transition transition)
            where T : Level, new()
        {
            _transition = transition;
            _transition.Initialize(Level, new T());
        }

        public override void LoadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if (_transition == null)
            {
                Level.Update(gameTime);
            }
            else
            {
                _transition.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_transition == null)
            {
                Level.Draw(spriteBatch);
            }
            else
            {
                _transition.Draw(spriteBatch);
            }
        }
    }
}
