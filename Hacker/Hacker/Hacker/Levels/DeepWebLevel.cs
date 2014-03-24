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
            Player.Instance.GameCompleteState = GameCompleteState.DataBankComplete;

            PushLayer(new MapLayer("deep_web"));
            PushLayer(new CollisionLayer("deep_web_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(224,832);
            objectLayer.GameObjectManager.AddGameObject(new Exit<CipherStoreLevel>(new Rectangle(640, 164, 64, 64), new Vector2(320,320)));

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

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            // Which one do you like better?
            // Syriana, "Gharib, Eccodek remix"
            SoundManager.PlayMusic("deepweb_foreign");
            //SoundManager.PlayMusic("deepweb_light");
        }
    }
}
