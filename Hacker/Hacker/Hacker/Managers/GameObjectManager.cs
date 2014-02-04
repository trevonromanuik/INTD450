using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Extensions;
using Hacker.GameObjects;

namespace Hacker.Managers
{
    public class GameObjectManager
    {
        public List<GameObject> GameObjects { get; private set; }

        public GameObjectManager()
        {
            GameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

        public GameObject GetGameObjectById(string id)
        {
            return GameObjects.Find(x => x.Id == id);
        }

        public Npc GetNpcByIp(string ip)
        {
            return (Npc)GameObjects.Find(x => x.IsInstanceOf(typeof(Npc)) && ((Npc)x).IpAddress == ip);
        }
    }
}
