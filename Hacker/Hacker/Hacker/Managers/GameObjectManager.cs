using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.GameObjects;

namespace Hacker.Managers
{
    class GameObjectManager
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
    }
}
