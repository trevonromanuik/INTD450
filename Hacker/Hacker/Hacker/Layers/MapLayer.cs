using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.GameObjects;
using Hacker.Managers;

namespace Hacker.Layers
{
    class MapLayer : Layer
    {
        public static MapLayer Instance
        {
            get { return instance ?? (instance = new MapLayer()); }
        }
        static MapLayer instance;

        public int[,] Tiles
        {
            get { return tiles; }
        }

        int[,] tiles = new int [,] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        Texture2D tileTexture;
        GameObjectManager gameObjectManager;

        public MapLayer()
        {
            tileTexture = AssetManager.LoadTexture("tile");
            gameObjectManager = new GameObjectManager();
            gameObjectManager.AddGameObject(Player.Instance);
        }

        public override void LoadContent()
        {
            
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            gameObjectManager.Update(gameTime);   
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0, iLength = tiles.GetLength(0); i < iLength; i++)
            {
                for (int j = 0, jLength = tiles.GetLength(1); j < jLength; j++)
                {
                    if (tiles[i,j] == 1)
                    {
                        spriteBatch.Draw(
                            tileTexture, 
                            new Vector2(32 * j, 32 * i), 
                            Color.White
                        );
                    }
                }
            }

            gameObjectManager.Draw(spriteBatch);
        }
    }
}
