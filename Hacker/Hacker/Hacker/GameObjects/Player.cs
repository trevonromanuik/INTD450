using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Player : GameObject
    {
        private static Player _instance;
        public static Player Instance
        {
            get { return _instance ?? (_instance = new Player()); }
        }

        public Player()
        {
            Id = "player";

            AddComponent(new Position(80, 80));

            Sprite sprite = new Sprite(AssetManager.LoadTexture("player"));
            AddComponent(sprite);

            AddComponent(new PlayerInput());
            AddComponent(new Collision());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
