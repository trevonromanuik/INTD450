using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Transitions;
using Hacker.Conversations;

namespace Hacker.Screens
{
    class LoginScreen : Screen
    {
        public static Layer Console;

        public LoginScreen(ScreenManager screenManager)
            : base(screenManager)
        {
            SoundManager.PlayMusic("intro");
            Console = new ConversationLayer(new LoginConversation(screenManager));
        }

        public override void LoadContent() 
        {

        }

        public override void Update(GameTime gameTime)
        {
            Console.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Console.Draw(spriteBatch);
        }
    }
}
