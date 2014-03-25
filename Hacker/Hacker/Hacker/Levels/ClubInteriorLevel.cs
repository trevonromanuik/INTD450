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
    class ClubInteriorLevel : Level
    {
        public ClubInteriorLevel()
            : base()
        {
            PushLayer(new MapLayer("club_interior"));
            PushLayer(new CollisionLayer("club_interior_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(448, 1088);

            Blackmoore blackmoore = new Blackmoore();
            objectLayer.GameObjectManager.AddGameObject(blackmoore);
            objectLayer.GameObjectManager.AddGameObject(new Wedge());

            bool triggered = false;
            objectLayer.GameObjectManager.AddGameObject(new Trigger(new Rectangle(320,448,384,192),() =>
                {
                    if (!triggered)
                    {
                        GameScreen.Level.PushLayer(new ConversationLayer(new BlackmooreConversation(blackmoore, blackmoore.Name, blackmoore.IpAddress)));
                        triggered = true;
                    }
                }));

            var juliana = new Juliana();
            juliana.RemoveComponent<Collision>();
            juliana.GetComponent<Position>().Teleport(1000, 1000);
            objectLayer.GameObjectManager.AddGameObject(juliana);

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.GameCompleteState = GameCompleteState.GameStart;
            Player.Instance.SpoofReset();
            SoundManager.PlayMusic("club_inside");
        }
    }
}
