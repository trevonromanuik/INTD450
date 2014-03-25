using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;

namespace Hacker.Levels
{
    class DeepWebLevel : Level
    {
        public DeepWebLevel()
            : base()
        {
            PushLayer(new MapLayer("deep_web"));
            PushLayer(new CollisionLayer("deep_web_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(224,832);

            objectLayer.GameObjectManager.AddGameObject(new Lamp(96, 832));
            objectLayer.GameObjectManager.AddGameObject(new Lamp(352, 832));
            objectLayer.GameObjectManager.AddGameObject(new Lamp(96, 512));
            objectLayer.GameObjectManager.AddGameObject(new Lamp(352, 512));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(608, 416, AssetManager.LoadTexture("dumpster")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(672, 832, AssetManager.LoadTexture("trashcan")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(145, 605, AssetManager.LoadTexture("trashcan")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(110, 600, AssetManager.LoadTexture("crate")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(128, 224, AssetManager.LoadTexture("crate")));

            objectLayer.GameObjectManager.AddGameObject(new NPC_Cat());
            objectLayer.GameObjectManager.AddGameObject(new NPC_SailorMoon());
            objectLayer.GameObjectManager.AddGameObject(new NPC_Mantis());
            objectLayer.GameObjectManager.AddGameObject(new NPC_Artist());
            objectLayer.GameObjectManager.AddGameObject(new NPC_Trash());

            InvisibleDoorSprite door1 = new InvisibleDoorSprite(), door2 = new InvisibleDoorSprite(), door3 = new InvisibleDoorSprite();
            objectLayer.GameObjectManager.AddGameObject(door1);
            door1.GetComponent<Position>().Teleport(270, 160);
            objectLayer.GameObjectManager.AddGameObject(door2);
            door2.GetComponent<Position>().Teleport(416, 160);
            objectLayer.GameObjectManager.AddGameObject(door3);
            door3.GetComponent<Position>().Teleport(640, 160);


            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.GameCompleteState = GameCompleteState.DataBankComplete;

            // Syriana, "Gharib, Eccodek remix"
            SoundManager.PlayMusic("deepweb_foreign");
        }
    }
}
