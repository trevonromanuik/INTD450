using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker.Conversations;
using Hacker.GameObjects;
using Hacker.Managers;

namespace Hacker.Layers
{
    class ConversationLayer : Layer
    {
        private Conversation _conversation;
        private Message currentMessage;

        Texture2D nameTexture;
        SpriteFont conversationFont;

        public ConversationLayer(Conversation conversation)
        {
            _conversation = conversation;
            currentMessage = conversation.First();
            currentMessage.Initialize();

            nameTexture = AssetManager.LoadTexture("name");
            conversationFont = AssetManager.LoadFont("Fonts/console_font");
        }

        public override void LoadContent()
        {
            
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if (currentMessage.Done)
            {
                currentMessage = currentMessage.Next();
                
                // check if conversation is over
                if (currentMessage == null)
                {
                    if (!string.IsNullOrEmpty(_conversation.IpAddress))
                    {
                        Player.Instance.AddRecentIpAddress(_conversation.Name, _conversation.IpAddress);
                    }
                    Level.PopLayer();
                    return;
                }
                else
                {
                    currentMessage.Initialize();
                }
            }

            currentMessage.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currentMessage.Draw(spriteBatch);
            spriteBatch.Draw(nameTexture, new Vector2(0, 374), Color.White);
            spriteBatch.DrawString(conversationFont, _conversation.Name, new Vector2(16, 380), Color.White);
        } 
    }
}
