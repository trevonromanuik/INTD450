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
    class InsideLevel : Level
    {
        public InsideLevel()
            : base()
        {
            PushLayer(new MapLayer("Level1"));
            PushLayer(new CollisionLayer("coll_level1"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            objectLayer.GameObjectManager.AddGameObject(new Terminal());
            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            SoundManager.PlayMusic("dance");
        }
    }
}
