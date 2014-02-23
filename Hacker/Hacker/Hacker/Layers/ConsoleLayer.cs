using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Levels;
using Hacker.Managers;
using Hacker.Screens;
using Hacker.Extensions;

namespace Hacker.Layers
{
    class ConsoleLayer : Layer
    {
        const double cursorTime = 0.4;
        const double backspaceTime = 0.4;

        const int maxInputLength = 56;
        const int maxPrevInputLength = 5;
        const int maxOutputLength = 27;

        Texture2D consoleTexture;
        SpriteFont consoleFont;

        double cursorTimer;
        bool showCursor;

        double backspaceTimer;

        bool hasPrevKeyState;
        KeyboardState keyState;
        KeyboardState prevKeyState;

        StringBuilder input;
        Queue<string> prevInput;
        int prevInputIndex;

        Queue<string> output;

        public ConsoleLayer()
        {
            consoleTexture = AssetManager.LoadTexture("console");
            consoleFont = AssetManager.LoadFont("Fonts/console_font");

            cursorTimer = 0.0;
            showCursor = true;

            backspaceTimer = 0.0;

            hasPrevKeyState = false;

            input = new StringBuilder();
            prevInput = new Queue<string>(maxPrevInputLength);
            prevInputIndex = -1;

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

            // handle up key
            if (IsKeyPressed(Keys.Up))
            {
                if (prevInputIndex < prevInput.Count - 1)
                {
                    input.Clear();
                    input.Append(prevInput.Reverse().ElementAt(++prevInputIndex));
                }

            }

            // handle down key
            if (IsKeyPressed(Keys.Down))
            {
                if (prevInputIndex > -1)
                {
                    prevInputIndex--;
                    input.Clear();
                    if (prevInputIndex > -1)
                    {
                        input.Append(prevInput.Reverse().ElementAt(prevInputIndex));
                    }
                }
            }

            // handle tilde key
            if (IsKeyPressed(Keys.OemTilde))
            {
                Level.PopLayer();
            }

            // handle alphanumeric keys
            AppendInput(TextInputManager.GetTextInput(prevKeyState, keyState));

            // handle backspace
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
            if (IsKeyPressed(Keys.Enter))
            {
                if (input.Length > 0)
                {
                    string s = input.ToString();
                    AddPrevInput(s);
                    prevInputIndex = -1;

                    AddOutput('>' + s);

                    input.Clear();

                    string[] split = s.Split(' ');
                    string token = split[0];
                    switch (token)
                    {
                        case "arp":
                            if (Player.Instance.IpAddresses.Count == 0)
                            {
                                AddOutput("No recent IP Addresses to display");
                            }
                            else
                            {
                                AddOutput("Name : Internet Address");
                                foreach (Tuple<string, string> ipAddress in Player.Instance.IpAddresses)
                                {
                                    AddOutput(ipAddress.Item1 + " : " + ipAddress.Item2);
                                }
                            }
                            break;
                        case "spoof":
                            if (split.Length != 2)
                            {
                                AddOutput("Invalid number of parameters");
                            }
                            else if (split[1] == "reset")
                            {
                                Player.Instance.SpoofReset();
                                AddOutput("Spoof reset successful");
                            }
                            else
                            {
                                Npc npc = GameScreen.Level.GetLayer<MapLayer>().GameObjectManager.GetNpcByIp(split[1]);
                                if (npc == null)
                                {
                                    AddOutput("Unknown IP Address: " + split[1]);
                                }
                                else
                                {
                                    Player.Instance.Spoof(npc);
                                    AddOutput("Spoof successful");
                                }
                            }
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
            spriteBatch.Begin();
            spriteBatch.Draw(consoleTexture, Vector2.Zero, Color.White * 0.8f);
            if (showCursor)
            {
                spriteBatch.DrawString(
                    consoleFont,
                    ">",
                    new Vector2(16, 470),
                    Color.White * 0.8f
                );
            }

            for (int i = 0; i < output.Count; i++)
            {
                spriteBatch.DrawString(
                    consoleFont,
                    output.ElementAt(i),
                    new Vector2(16, (i * 16) + 8),
                    Color.White * 0.8f
                );
            }

            spriteBatch.DrawString(
                consoleFont, 
                input.ToString(),
                new Vector2(28, 470), 
                Color.White * 0.8f
            );

            spriteBatch.End();
        }

        public bool IsKeyPressed(Keys key)
        {
            return hasPrevKeyState && prevKeyState.IsKeyUp(key)
                && keyState.IsKeyDown(key);
        }

        public void AppendInput(string s)
        {
            if (input.Length < maxInputLength)
            {
                input.Append(s);
                if (input.Length > maxInputLength)
                {
                    input.Remove(maxInputLength - 1, input.Length - maxInputLength);
                }
            }
        }

        public void AddPrevInput(string s)
        {
            if (prevInput.Count == maxPrevInputLength)
            {
                prevInput.Dequeue();
            }
            prevInput.Enqueue(s);
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
