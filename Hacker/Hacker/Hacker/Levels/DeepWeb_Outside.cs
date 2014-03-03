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
    class DeepWeb_Outside : Level
    {
        public DeepWeb_Outside()
            : base()
        {
            //PushLayer(new MapLayer("deepweb"));
           // PushLayer(new CollisionLayer("coll_deepweb"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            objectLayer.GameObjectManager.AddGameObject(new Exit<InsideLevel>(new Vector2(320, 256), new Vector2(320, 288)));
            PushLayer(objectLayer);

            CameraManager.CameraTarget = Player.Instance;
        }

        public override void OnLoad()
        {
            //SoundManager.PlayMusic("deeweb_dark");
        }
    }
}
