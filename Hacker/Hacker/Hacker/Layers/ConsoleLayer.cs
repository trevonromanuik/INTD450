using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker.GameObjects;
using Hacker.Levels;
using Hacker.Managers;

namespace Hacker.Layers
{
    class ConsoleLayer : Layer
    {
        const double cursorTime = 0.4;
        const double backspaceTime = 0.4;

        const int maxOutputLength = 13;

        Texture2D consoleTexture;
        SpriteFont consoleFont;

        double cursorTimer;
        bool showCursor;

        double backspaceTimer;

        bool hasPrevKeyState;
        KeyboardState keyState;
        KeyboardState prevKeyState;

        StringBuilder input;
        Queue<string> output;


        #region alphanumeric key mappings

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
            { Keys.Z, 'z' },
            { Keys.D1, '1' },
            { Keys.D2, '2' },
            { Keys.D3, '3' },
            { Keys.D4, '4' },
            { Keys.D5, '5' },
            { Keys.D6, '6' },
            { Keys.D7, '7' },
            { Keys.D8, '8' },
            { Keys.D9, '9' },
            { Keys.D0, '0' }
        };

        #endregion

        public ConsoleLayer()
        {
            consoleTexture = AssetManager.LoadTexture("console");
            consoleFont = AssetManager.LoadFont("Fonts/console_font");

            cursorTimer = 0.0;
            showCursor = true;

            backspaceTimer = 0.0;

            hasPrevKeyState = false;

            input = new StringBuilder();
            output = new Queue<string>(maxOutputLength);
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

            cursorTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (cursorTimer > cursorTime)
            {
                cursorTimer -= cursorTime;
                showCursor = !showCursor;
            }

            // handle tilde key
            if (hasPrevKeyState && prevKeyState.IsKeyUp(Keys.OemTilde)
                && keyState.IsKeyDown(Keys.OemTilde))
            {
                Level.PopLayer();
            }

            // handle alphanumeric keys
            foreach (Keys key in keys.Keys)
            {
                if (hasPrevKeyState && prevKeyState.IsKeyUp(key) 
                    && keyState.IsKeyDown(key))
                {
                    KeyPressed(key);
                }
            }

            // handle backspace
            // TODO: make holding backspace delete multiple characters
            if (keyState.IsKeyDown(Keys.Back))
            {
                bool pressBack = false;
                if (hasPrevKeyState && prevKeyState.IsKeyUp(Keys.Back))
                {
                    backspaceTimer = 0.0;
                    pressBack = true;
                }
                else
                {
                    backspaceTimer += gameTime.ElapsedGameTime.TotalSeconds;
                    if (backspaceTimer > backspaceTime)
                    {
                        pressBack = true;
                    }
                }

                if (pressBack && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
            }

            // handle enter key
            if (hasPrevKeyState && prevKeyState.IsKeyUp(Keys.Enter) 
                && keyState.IsKeyDown(Keys.Enter))
            {
                if (input.Length > 0)
                {
                    string s = input.ToString();
                    AddOutput('>' + s);

                    input.Clear();

                    string[] split = s.Split(' ');
                    string token = split[0];
                    switch (token)
                    {
                        case "arp":
                            break;
                        case "spoof":
                            break;
                        default:
                            AddOutput("Unknown command: " + token);
                            break;

                    }
                }
            }

            prevKeyState = keyState;
            hasPrevKeyState = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(consoleTexture, Vector2.Zero, Color.White * 0.8f);
            if (showCursor)
            {
                spriteBatch.DrawString(
                    consoleFont,
                    ">",
                    new Vector2(8, 229),
                    Color.White * 0.8f
                );
            }

            for (int i = 0; i < output.Count; i++)
            {
                spriteBatch.DrawString(
                    consoleFont,
                    output.ElementAt(i),
                    new Vector2(8, (i * 16) + 4),
                    Color.White * 0.8f
                );
            }

            spriteBatch.DrawString(
                consoleFont, 
                input.ToString(),
                new Vector2(20, 229), 
                Color.White * 0.8f
            );
        }

        public void KeyPressed(Keys key)
        {
            if (input.Length < 28)
            {
                input.Append(keys[key]);
            }
        }

        public void AddOutput(string s)
        {
            if (output.Count == maxOutputLength)
            {
                output.Dequeue();
            }
            output.Enqueue(s);
        }
    }
}
