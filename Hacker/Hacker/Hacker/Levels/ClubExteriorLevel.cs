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
    class ClubExteriorLevel : Level
    {
        public ClubExteriorLevel()
            : base()
        {
            PushLayer(new MapLayer("club_exterior"));
            PushLayer(new CollisionLayer("club_exterior_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(832, 320);
            
            objectLayer.GameObjectManager.AddGameObject(new Juliana());
            objectLayer.GameObjectManager.AddGameObject(new Bouncer());

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            SoundManager.PlayMusic("club_outside");
        }
    }
}
