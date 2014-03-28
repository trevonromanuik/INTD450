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
        protected const double textTime = 0.05;
        protected const double markerTime = 0.4;

        Textbox _textbox;

        protected Texture2D markerTexture;
        protected SpriteFont conversationFont;

        protected double textTimer;
        protected int textIndex;

        protected double markerTimer;
        protected bool showMarker;

        protected bool hasPrevKeyState;
        protected KeyboardState keyState;
        protected KeyboardState prevKeyState;

        public string Text 
        {
            get { return _text; }
            private set { _text = FormatText(value); }
        }
        private string _text;

        public Func<bool> Condition { get; private set; }
        public Action Action { get; private set; }

        public List<Message> Messages { get; private set; }

        public bool Done { get; protected set; }

        public Message(string text)
            : this(text, () => true)
        {

        }

        public Message(string text, Func<bool> condition)
            : this(text, condition, () => { })
        {

        }

        public Message(string text, Func<bool> func, Action action)
        {
            markerTexture = AssetManager.LoadTexture("marker");
            conversationFont = AssetManager.LoadFont("Fonts/console_font");

            Text = text;
            Condition = func;
            Action = action;

            Messages = new List<Message>();

            _textbox = new Textbox(0, 400, 640, 112);
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
            return Messages.FirstOrDefault(x => x.Condition());
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
            _textbox.Draw(spriteBatch);

            spriteBatch.DrawStringFront(
                conversationFont,
                Text.Substring(0, textIndex),
                new Vector2(16, 414),
                Color.White
            );

            if (showMarker)
            {
                spriteBatch.DrawFront(
                    markerTexture,
                    new Vector2(596, 484),
                    Color.White
                );
            }
        }

        private string FormatText(string text)
        {
            if (conversationFont.MeasureString(text).X <= 608)
            {
                return text;
            }

            int startIndex = 0;
            int prevIndex = startIndex, index = -1;
            while (conversationFont.MeasureString(text.Substring(startIndex)).X > 608)
            {
                index = text.IndexOf(' ', prevIndex + 1);
                if (index == -1)
                {
                    if (prevIndex == startIndex)
                    {
                        throw new ArgumentException("text is too long to format", "text");
                    }
                    else
                    {
                        index = text.Length - 1;
                    }
                }

                if (conversationFont.MeasureString(text.Substring(startIndex, index - startIndex)).X > 608)
                {
                    text = text.Remove(prevIndex, 1).Insert(prevIndex, "\n");
                    startIndex = prevIndex;
                }
                else
                {
                    prevIndex = index;
                }
            }

            return text;
        }
    }
}
