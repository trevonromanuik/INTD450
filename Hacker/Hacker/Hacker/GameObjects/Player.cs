﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Managers;
using Hacker.Helpers;

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

        const int maxDDOSCount = 3;
        public List<Npc> DDOSList { get; private set; }

        private Dictionary<string, Animation> animations;

        public string SpoofId { get; private set; }

        public Player()
        {
            Id = "player";
            SpoofId = null;

            AddComponent(new Position(160, 352));
            AddComponent(new Shadow());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("player_up"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("player_down"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("player_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("player_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            // save a reference to the original animations for spoofing
            animations = sprite.Animations;

            AddComponent(new PlayerInput());
            AddComponent(new Collision());

            IpAddresses = new List<Tuple<string, string>>(maxIpAddressCount);
            DDOSList = new List<Npc>(maxDDOSCount);
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

<<<<<<< HEAD
        public void Keylog(Npc npc)
        {
            var keylogInfo = npc.GetComponent<Keyloggable>();
            if (keylogInfo != null)
            {  
                var path = keylogInfo.KeyLogPath;
                FileWriterHelper.writeFile(path);
            }

            
=======
        public void DDOS(Npc npc)
        {
            int index = DDOSList.FindIndex(x => x.Id == npc.Id);
            if (index != -1)
            {
                DDOSList.RemoveAt(index);
            }

            if (DDOSList.Count >= maxDDOSCount)
            {
                var _npc = DDOSList[0];
                _npc.GetComponent<DDOSable>().UnDDOS();
                DDOSList.RemoveAt(0);
            }

            npc.GetComponent<DDOSable>().DDOS();
            DDOSList.Add(npc);
>>>>>>> 4973a2eec8d6ed4725c1e3928ce821af0cd26c74
        }
    }
}
