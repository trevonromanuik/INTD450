using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker.GameObjects;
using Hacker.Managers;

namespace Hacker.Layers
{
    class ConsoleLayer : Layer
    {
        const double cursorTime = 0.4;

        Texture2D consoleTexture;
        Texture2D cursorTexture;
        double timer;
        bool showCursor;

        KeyboardState keyState;
        KeyboardState prevKeyState;

        StringBuilder input;

        #region key mappings

        readonly Dictionary<Keys, char> keys = new Dictionary<Keys, char>
        {
            { Keys.A, 'a' },
            { Keys.B, 'b' },
            { Keys.C, 'c' },
            { Keys.D, 'd' },
            { Keys.E, 'e' },
            { Keys.F, 'f' },
            { Keys.G, 'g' },
            { Keys.H, 'h' },
            { Keys.I, 'i' },
            { Keys.J, 'j' },
            { Keys.K, 'k' },
            { Keys.L, 'l' },
            { Keys.M, 'm' },
            { Keys.N, 'n' },
            { Keys.O, 'o' },
            { Keys.P, 'p' },
            { Keys.Q, 'q' },
            { Keys.R, 'r' },
            { Keys.S, 's' },
            { Keys.T, 't' },
            { Keys.U, 'u' },
            { Keys.V, 'v' },
            { Keys.W, 'w' },
            { Keys.X, 'x' },
            { Keys.Y, 'y' },
            { Keys.Z, 'z' }
        };

        #endregion

        public ConsoleLayer()
        {
            consoleTexture = AssetManager.LoadTexture("console.png");
            cursorTexture = AssetManager.LoadTexture("cursor");

            timer = 0.0f;
            showCursor = true;
        }

        public override void LoadContent()
        {

        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > cursorTime)
            {
                timer -= cursorTime;
                showCursor = !showCursor;
            }

            foreach (Keys key in keys.Keys)
            {
                if (prevKeyState != null && prevKeyState.IsKeyUp(key) && keyState.IsKeyDown(key))
                {
                    KeyPressed(key);
                }
            }

            prevKeyState = keyState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(consoleTexture, Vector2.Zero, Color.White * 0.8f);
            if (showCursor)
            {
                spriteBatch.Draw(cursorTexture, new Vector2(6, 228), Color.White);
                //spriteBatch.DrawString(
            }
        }

        public void KeyPressed(Keys key)
        {
            input.Append(keys[key]);
        }
    }
}
