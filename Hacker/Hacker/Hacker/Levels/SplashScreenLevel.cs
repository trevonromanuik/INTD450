using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.Levels
{
    class SplashScreenLevel : Level
    {
        public SplashScreenLevel()
            : base()
        {
            PushLayer(new MapLayer("background"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(new SplashScreen());
            PushLayer(objectLayer);
            PushLayer(new ConversationLayer(new LoginConversation()));
        }

        public override void OnLoad()
        {
             SoundManager.PlayMusic("intro");
        }
    }
}
