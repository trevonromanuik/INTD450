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
    class ClubOfficeLevel : Level
    {
        public ClubOfficeLevel()
            : base()
        {
            PushLayer(new MapLayer("office"));
            PushLayer(new CollisionLayer("office_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(new OfficeTerminal(320, 224));
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);

            objectLayer.GameObjectManager.AddGameObject(new Trigger(new Rectangle(256, 480, 128, 64), () =>
            {
                if (Player.Instance.GameCompleteState == GameCompleteState.ClubComplete)
                {
                    GameScreen.LoadLevel<HubLevel>(new FadeTransition(new Vector2(320, 384)));
                }
                else
                {
                    GameScreen.LoadLevel<ClubInteriorLevel>(new FadeTransition(new Vector2(1024, 320)));
                }
            }));

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.SpoofReset();
            Player.Instance.GameCompleteState = GameCompleteState.GameStart;
        }
    }
}
