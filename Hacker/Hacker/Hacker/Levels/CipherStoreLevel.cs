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
    class CipherStoreLevel : Level
    {
        public CipherStoreLevel()
            : base()
        {
            PushLayer(new MapLayer("cipher_store"));
            PushLayer(new CollisionLayer("cipher_store_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            objectLayer.GameObjectManager.AddGameObject(new Exit<DeepWebLevel>(new Rectangle(256, 480, 128, 64), new Vector2(640, 228)));
            objectLayer.GameObjectManager.AddGameObject(new Cipher());
            PushLayer(objectLayer);
        }

    }
}
