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
            PushLayer(objectLayer);
        }
    }
}
