﻿using System;
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
            PushLayer(new MapLayer("Content/Levels/Level1.txt"));
            PushLayer(new CollisionLayer(new int[,] {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            }));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            objectLayer.GameObjectManager.AddGameObject(new Spoofie());
            objectLayer.GameObjectManager.AddGameObject(new Exit<InsideLevel>(new Vector2(320, 96), new Vector2(320, 384)));
            objectLayer.GameObjectManager.AddGameObject(new Bouncer());
            PushLayer(objectLayer);

            CameraManager.CameraTarget = Player.Instance;
        }

        public override void OnLoad()
        {
            SoundManager.PlayMusic("dance");
        }
    }
}
