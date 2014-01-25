﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker.Conversations;
using Hacker.Managers;

namespace Hacker.Layers
{
    class ConversationLayer : Layer
    {
        const double textTime = 0.1;
        const double markerTime = 0.4;

        private Conversation _conversation;
        private int messageIndex;

        Texture2D conversationTexture;
        Texture2D markerTexture;
        SpriteFont conversationFont;

        double textTimer;
        int textIndex;

        double markerTimer;
        bool showMarker;

        bool hasPrevKeyState;
        KeyboardState keyState;
        KeyboardState prevKeyState;

        public ConversationLayer(Conversation conversation)
        {
            _conversation = conversation;
            messageIndex = 0;

            conversationTexture = AssetManager.LoadTexture("conversation");
            markerTexture = AssetManager.LoadTexture("marker");
            conversationFont = AssetManager.LoadFont("Fonts/console_font");

            textTimer = 0.0;
            textIndex = 1;

            markerTimer = 0.0;
            showMarker = true;

            hasPrevKeyState = false;
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

            textTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (textTimer > textTime)
            {
                textTimer -= textTime;
                textIndex = Math.Min(
                    textIndex + 1,
                    _conversation.Messages[messageIndex].Text.Length
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
                if (textIndex < _conversation.Messages[messageIndex].Text.Length)
                {
                    textIndex = _conversation.Messages[messageIndex].Text.Length;
                }
                else
                {
                    textTimer = 0.0;
                    textIndex = 1;

                    markerTimer = 0.0;
                    showMarker = true;

                    messageIndex++;
                    if (messageIndex == _conversation.Messages.Count)
                    {
                        Level.PopLayer();
                    }
                }
            }

            prevKeyState = keyState;
            hasPrevKeyState = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                conversationTexture, 
                new Vector2(0, 160), 
                Color.White
            );

            spriteBatch.DrawString(
                conversationFont,
                _conversation.Messages[messageIndex].Text.Substring(0, textIndex),
                new Vector2(8, 165),
                Color.White
            );

            if (showMarker)
            {
                spriteBatch.Draw(
                    markerTexture,
                    new Vector2(298, 242),
                    Color.White
                );
            }
        } 
    }
}
