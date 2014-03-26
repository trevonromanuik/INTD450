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
    class VaultLevel : Level
    {
        public VaultLevel()
            : base()
        {
            PushLayer(new MapLayer("vault"));
            PushLayer(new CollisionLayer("vault_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(new VaultTerminal(320,224));
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);

            objectLayer.GameObjectManager.AddGameObject(new Trigger(new Rectangle(256, 480, 128, 64), () =>
            {
                if (Player.Instance.GameCompleteState == GameCompleteState.DataBankComplete)
                {
                    GameScreen.LoadLevel<HubLevel>(new FadeTransition(new Vector2(320, 384)));
                }
                else
                {
                    GameScreen.LoadLevel<DataBankLevel>(new FadeTransition(new Vector2(352, 416)));
                }
            }));

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.SpoofReset();
            Player.Instance.GameCompleteState = GameCompleteState.ClubComplete;
        }
    }
}
