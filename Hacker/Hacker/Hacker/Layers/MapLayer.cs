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
    abstract class MapLayer : Layer
    {
        public abstract int[,] Tiles { get; }

        Texture2D tileTexture;
        public GameObjectManager GameObjectManager { get; private set; }

        public MapLayer()
        {
            tileTexture = AssetManager.LoadTexture("tile");
            GameObjectManager = new GameObjectManager();
        }

        public override void LoadContent()
        {
            
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            GameObjectManager.Update(gameTime);   
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0, iLength = Tiles.GetLength(0); i < iLength; i++)
            {
                for (int j = 0, jLength = Tiles.GetLength(1); j < jLength; j++)
                {
                    if (Tiles[i,j] == 1)
                    {
                        spriteBatch.Draw(
                            tileTexture, 
                            new Vector2(tileTexture.Width * j, tileTexture.Height * i), 
                            Color.White
                        );
                    }
                }
            }

            GameObjectManager.Draw(spriteBatch);
        }
    }
}
