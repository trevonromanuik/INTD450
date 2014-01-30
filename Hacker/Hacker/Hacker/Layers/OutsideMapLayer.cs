using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.GameObjects;
using Hacker.Levels;
using Hacker.Managers;

namespace Hacker.Layers
{
    class OutsideMapLayer : MapLayer
    {
        public override int[,] Tiles
        {
            get { return tiles; }
        }

        int[,] tiles = new int[,] {
            { 0, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
            { 0, 2, 2, 2, 1, 1, 2, 2, 2, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public OutsideMapLayer()
            : base()
        {
            GameObjectManager.AddGameObject(Player.Instance);
            GameObjectManager.AddGameObject(new Spoofie());
            GameObjectManager.AddGameObject(new Bouncer());
            GameObjectManager.AddGameObject(new Exit<InsideLevel>(new Vector2(320, 96), new Vector2(320, 384)));
        }
    }
}
