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
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("player_up"), 32, 32, 1, false));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("player_down"), 32, 32, 1, false));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("player_left"), 32, 32, 1, false));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("player_right"), 32, 32, 1, false));
            sprite.PlayAnimation("down");
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
