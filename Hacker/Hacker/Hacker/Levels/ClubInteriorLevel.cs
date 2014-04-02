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
            PushLayer(new AnimatedMapLayer(new string[5]{"club_interior_1","club_interior_2","club_interior_3","club_interior_4","club_interior_5"}, 2));
            PushLayer(new CollisionLayer("club_interior_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);

            Blackmoore blackmoore = new Blackmoore();
            objectLayer.GameObjectManager.AddGameObject(blackmoore);
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
            juliana.GetComponent<Position>().Teleport(2048, 2048);
            objectLayer.GameObjectManager.AddGameObject(juliana);

            objectLayer.GameObjectManager.AddGameObject(new Wedge());
            objectLayer.GameObjectManager.AddGameObject(new NPC_Parti1());
            objectLayer.GameObjectManager.AddGameObject(new NPC_Parti2());
            objectLayer.GameObjectManager.AddGameObject(new NPC_Artist());

            var door = new Placeable(1024, 280, AssetManager.LoadTexture("metal_door"));
            door.AddComponent(new ConversationInteraction(new DoorConversation(door)));
            objectLayer.GameObjectManager.AddGameObject(door);

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
