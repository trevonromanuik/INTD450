using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;

namespace Hacker.Levels
{
    class OutsideLevel : Level
    {
        public OutsideLevel()
            : base()
        {
            PushLayer(new MapLayer("Level1"));
            PushLayer(new CollisionLayer("coll_level1"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            objectLayer.GameObjectManager.AddGameObject(new Spoofie());
            objectLayer.GameObjectManager.AddGameObject(new Exit<InsideLevel>(new Vector2(320, 96), new Vector2(320, 384)));
            objectLayer.GameObjectManager.AddGameObject(new Bouncer());
            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            SoundManager.PlayMusic("dance");
        }
    }
}
