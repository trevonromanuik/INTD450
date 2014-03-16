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
    class ClubInteriorLevel : Level
    {
        public ClubInteriorLevel()
            : base()
        {
            PushLayer(new MapLayer("club_interior"));
            PushLayer(new CollisionLayer("club_interior_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(128, 320);

            PushLayer(objectLayer);
        }
    }
}
