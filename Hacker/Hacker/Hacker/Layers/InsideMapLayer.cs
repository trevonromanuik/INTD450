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
    class InsideMapLayer : MapLayer
    {
        public override int[,] Tiles
        {
            get { return tiles; }
        }

        int[,] tiles = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
            { 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public InsideMapLayer()
            : base()
        {
            GameObjectManager.AddGameObject(Player.Instance);
            GameObjectManager.AddGameObject(new Exit<OutsideLevel>(new Vector2(64, 64)));
        }
    }
}
