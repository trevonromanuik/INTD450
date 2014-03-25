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
            
            objectLayer.GameObjectManager.AddGameObject(new Juliana());
            objectLayer.GameObjectManager.AddGameObject(new Bouncer());

            objectLayer.GameObjectManager.AddGameObject(new Exit<ClubInteriorLevel>(new Rectangle(512, 128, 128, 100), new Vector2(448, 1024)));

            var blackmoore = new Blackmoore();
            blackmoore.RemoveComponent<Collision>();
            blackmoore.GetComponent<Position>().Teleport(1000, 1000);
            objectLayer.GameObjectManager.AddGameObject(blackmoore);

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.GameCompleteState = GameCompleteState.GameStart;
            Player.Instance.SpoofReset();
            Player.Instance.GetComponent<Position>().Teleport(832, 320);
            SoundManager.PlayMusic("club_outside");
        }
    }
}
