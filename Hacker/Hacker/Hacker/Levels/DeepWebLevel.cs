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
    class DeepWebLevel : Level
    {
        public DeepWebLevel()
            : base()
        {
            PushLayer(new MapLayer("deep_web"));
            PushLayer(new CollisionLayer("deep_web_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(96,832);
            PushLayer(objectLayer);
        }
    }
}
