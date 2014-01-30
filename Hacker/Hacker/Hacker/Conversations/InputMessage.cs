using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker.Extensions;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Transitions;

namespace Hacker.Conversations
{
    class InputMessage : Message
    {
        const int maxInputLength = 56;

        const double cursorTime = 0.4;
        const double backspaceTime = 0.4;

        StringBuilder input;
        Texture2D inputTexture;

        double cursorTimer;
        bool showCursor;

        double backspaceTimer;

        public string Output { get { return input.ToString(); } }

        public InputMessage(string text)
            : this(text, () => true)
        {

        }

        public InputMessage(string text, Func<bool> func)
            : this(text, func, () => { })
        {

        }

        public InputMessage(string text, Func<bool> func, Action action)
            : base(text, func)
        {
            input = new StringBuilder();
            inputTexture = AssetManager.LoadTexture("input");
        }

        public override void Initialize()
        {
            base.Initialize();

            input.Clear();

            cursorTimer = 0.0;
            showCursor = true;

            backspaceTimer = 0.0;
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

            textTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (textTimer > textTime)
            {
                textTimer -= textTime;
                textIndex = Math.Min(
                    textIndex + 1,
                    Text.Length
                );
            }

            markerTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (markerTimer > markerTime)
            {
                markerTimer -= markerTimer;
                showMarker = !showMarker;
            }

            // handle alphanumeric keys
            if (textIndex == Text.Length)
            {
                AppendInput(TextInputManager.GetTextInput(prevKeyState, keyState));
            }

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
            if (hasPrevKeyState && prevKeyState.IsKeyUp(Keys.Enter)
                && keyState.IsKeyDown(Keys.Enter))
            {
                if (textIndex < Text.Length)
                {
                    textIndex = Text.Length;
                }
                else if (input.Length > 0)
                {
                    textTimer = 0.0;
                    textIndex = 1;

                    markerTimer = 0.0;
                    showMarker = true;

                    Action();
                    Done = true;
                }
            }

            prevKeyState = keyState;
            hasPrevKeyState = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (textIndex == Text.Length)
            {
                spriteBatch.Draw(inputTexture, new Vector2(0, 464), Color.White);
                if (showCursor)
                {
                    spriteBatch.DrawString(
                        conversationFont,
                        ">",
                        new Vector2(16, 478),
                        Color.White
                    );
                }

                spriteBatch.DrawString(
                    conversationFont,
                    input.ToString(),
                    new Vector2(28, 478),
                    Color.White
                );
            }
        }

        void AppendInput(string s)
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
    }
}
