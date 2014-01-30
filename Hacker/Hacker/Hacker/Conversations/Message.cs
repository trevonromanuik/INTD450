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
    class Message
    {
        protected const double textTime = 0.1;
        protected const double markerTime = 0.4;

        protected Texture2D conversationTexture;
        protected Texture2D markerTexture;
        protected SpriteFont conversationFont;

        protected double textTimer;
        protected int textIndex;

        protected double markerTimer;
        protected bool showMarker;

        protected bool hasPrevKeyState;
        protected KeyboardState keyState;
        protected KeyboardState prevKeyState;

        public string Text { get; private set; }
        public Func<bool> Func { get; private set; }
        public Action Action { get; private set; }

        public List<Message> Messages { get; private set; }

        public bool Done { get; protected set; }

        public Message(string text)
            : this(text, () => true)
        {

        }

        public Message(string text, Func<bool> func)
            : this(text, func, () => { })
        {

        }

        public Message(string text, Func<bool> func, Action action)
        {
            Text = text;
            Func = func;
            Action = action;

            Messages = new List<Message>();

            conversationTexture = AssetManager.LoadTexture("conversation");
            markerTexture = AssetManager.LoadTexture("marker");
            conversationFont = AssetManager.LoadFont("Fonts/console_font");
        }

        public virtual void Initialize()
        {
            Done = false;

            textTimer = 0.0;
            textIndex = 1;

            markerTimer = 0.0;
            showMarker = true;

            hasPrevKeyState = false;
        }

        public Message Next()
        {
            return Messages.FirstOrDefault(x => x.Func());
        }

        public virtual void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

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

            // handle enter key
            if (hasPrevKeyState && prevKeyState.IsKeyUp(Keys.Enter)
                && keyState.IsKeyDown(Keys.Enter))
            {
                if (textIndex < Text.Length)
                {
                    textIndex = Text.Length;
                }
                else
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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                conversationTexture,
                new Vector2(0, 320),
                Color.White
            );

            spriteBatch.DrawString(
                conversationFont,
                Text.Substring(0, textIndex),
                new Vector2(16, 326),
                Color.White
            );

            if (showMarker)
            {
                spriteBatch.Draw(
                    markerTexture,
                    new Vector2(596, 484),
                    Color.White
                );
            }
        }
    }
}
