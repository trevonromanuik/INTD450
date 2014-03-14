﻿using System;
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
    class HubLevel : Level
    {
        public HubLevel()
            : base()
        {
            PushLayer(new MapLayer("hub"));
            PushLayer(new CollisionLayer("hub_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(320, 384);

            objectLayer.GameObjectManager.AddGameObject(new Anon());
            PushLayer(objectLayer);
        }
    }
}
