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
            objectLayer.GameObjectManager.AddGameObject(new Exit<CipherStoreLevel>(new Vector2(640, 164), new Vector2(256, 448), false));

            objectLayer.GameObjectManager.AddGameObject(new Placeable(96, 832, AssetManager.LoadTexture("lam1p")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(352, 832, AssetManager.LoadTexture("lam1p")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(96, 512, AssetManager.LoadTexture("lam1p")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(352, 512, AssetManager.LoadTexture("lam1p")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(608, 416, AssetManager.LoadTexture("dumpster")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(672, 832, AssetManager.LoadTexture("trashcan")));

            objectLayer.GameObjectManager.AddGameObject(new NPC_Cat());
            objectLayer.GameObjectManager.AddGameObject(new NPC_SailorMoon());

            PushLayer(objectLayer);
        }
    }
}
