using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Screens;
using Hacker.Transitions;

namespace Hacker.Levels
{
    class CipherStoreLevel : Level
    {
        public CipherStoreLevel()
            : base()
        {
            PushLayer(new MapLayer("cipher_store"));
            PushLayer(new CollisionLayer("cipher_store_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            objectLayer.GameObjectManager.AddGameObject(new Cipher());

            objectLayer.GameObjectManager.AddGameObject(new Trigger(new Rectangle(256, 480, 128, 64), () =>
            {
                if (Player.Instance.GameCompleteState == GameCompleteState.DeepWebComplete)
                {
                    GameScreen.LoadLevel<HubLevel>(new FadeTransition(new Vector2(320, 384)));
                }
                else
                {
                    GameScreen.LoadLevel<DeepWebLevel>(new FadeTransition(new Vector2(640, 228)));
                }
            }));

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.GameCompleteState = GameCompleteState.DataBankComplete;
        }
    }
}
