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

        const int maxIpAddressCount = 5;
        public List<Tuple<string, string>> IpAddresses { get; private set; }

        private Dictionary<string, Animation> animations;

        public string SpoofId { get; private set; }

        public Player()
        {
            Id = "player";
            SpoofId = null;

            AddComponent(new Position(80, 80));

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("player_up"), 32, 32, 1, false));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("player_down"), 32, 32, 1, false));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("player_left"), 32, 32, 1, false));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("player_right"), 32, 32, 1, false));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            // save a reference to the original animations for spoofing
            animations = sprite.Animations;

            AddComponent(new PlayerInput());
            AddComponent(new Collision());

            IpAddresses = new List<Tuple<string, string>>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void AddRecentIpAddress(string name, string ipAddress)
        {
            int index = IpAddresses.FindIndex(x => x.Item2 == ipAddress);
            if (index != -1)
            {
                IpAddresses.RemoveAt(index);
            }

            if (IpAddresses.Count >= maxIpAddressCount)
            {
                IpAddresses.RemoveAt(0);
            }

            IpAddresses.Add(Tuple.Create(name, ipAddress));
        }

        public void Spoof(Npc npc)
        {
            SpoofId = npc.Id;

            var sprite = GetComponent<AnimatedSprite>();
            var npcSprite = npc.GetComponent<AnimatedSprite>();
            sprite.Animations = npcSprite.Animations;
        }

        public void SpoofReset()
        {
            SpoofId = null;

            var _sprite = GetComponent<AnimatedSprite>();
            _sprite.Animations = animations;
        }
    }
}
