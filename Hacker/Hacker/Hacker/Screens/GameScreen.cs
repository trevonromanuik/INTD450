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
        private static Dictionary<Type, Level> levels = new Dictionary<Type, Level>();
        public static Level Level { get; private set; }
        static Transition _transition;

        public GameScreen(ScreenManager screenManager)
            : base(screenManager)
        {
            //LoadLevel<DeepWebLevel>();
            //LoadLevel<DataBankLevel>();
            //LoadLevel<VaultLevel>();
            //LoadLevel<ClubExteriorLevel>();
            LoadLevel<HubLevel>();
        }

        public static void LoadLevel(Level level)
        {
            Level = level;
            Level.OnLoad();
        }

        public static void LoadLevel<T>() where T : Level, new()
        {
            if (!levels.ContainsKey(typeof(T)))
            {
                levels[typeof(T)] = new T();
            }
            Level = levels[typeof(T)];
            Level.OnLoad();
        }

        public static void LoadLevel<T>(Transition transition)
            where T : Level, new()
        {
            _transition = transition;
            if (!levels.ContainsKey(typeof(T)))
            {
                levels[typeof(T)] = new T();
            }
            _transition.Initialize(Level, levels[typeof(T)]);
        }

        public static void RemoveTransition()
        {
            _transition = null;
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
