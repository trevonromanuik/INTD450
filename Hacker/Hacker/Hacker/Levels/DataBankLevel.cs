using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;

namespace Hacker.Levels
{
    class DataBankLevel : Level
    {
        public DataBankLevel()
            : base()
        {
            PushLayer(new MapLayer("data_bank"));
            PushLayer(new CollisionLayer("data_bank_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(640, 1472);

            objectLayer.GameObjectManager.AddGameObject(new Counter(64, 640, 11));
            objectLayer.GameObjectManager.AddGameObject(new Counter(896, 640, 5));
            objectLayer.GameObjectManager.AddGameObject(new Counter(704, 832, 5));
            objectLayer.GameObjectManager.AddGameObject(new Counter(64, 1152, 3));
            objectLayer.GameObjectManager.AddGameObject(new Counter(1024, 1280, 3));
            objectLayer.GameObjectManager.AddGameObject(new CounterTop(192, 640, 8));
            objectLayer.GameObjectManager.AddGameObject(new CounterTop(1024, 640, 10));
            PushLayer(objectLayer);
        }
    }
}
