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

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("link_up"), 12, 15, 0.2f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("link_down"), 13, 16, 0.2f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("link_left"), 14, 16, 0.2f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("link_right"), 14, 16, 0.2f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new PlayerInput());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
