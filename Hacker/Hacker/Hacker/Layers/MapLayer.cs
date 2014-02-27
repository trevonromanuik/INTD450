﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.GameObjects;
using Hacker.Levels;
using Hacker.Managers;
using Hacker.Extensions;

namespace Hacker.Layers
{
    abstract class MapLayer : Layer
    {
        public abstract int[,] Tiles { get; }

        Texture2D tileTexture;
        Texture2D wallTexture;

        public MapLayer()
        {
            tileTexture = AssetManager.LoadTexture("tile");
            wallTexture = AssetManager.LoadTexture("wall");
        }

        public override void LoadContent()
        {
            
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            for (int i = 0, iLength = Tiles.GetLength(0); i < iLength; i++)
            {
                for (int j = 0, jLength = Tiles.GetLength(1); j < jLength; j++)
                {
                    Texture2D texture = null;
                    switch (Tiles[i, j])
                    {
                        case 1:
                            texture = tileTexture;
                            break;
                        case 2:
                            texture = wallTexture;
                            break;

                    }

                    if (texture != null)
                    {
                        var screenPosition = CameraManager.GetScreenPosition(new Vector2(texture.Width * j, texture.Height * i));
                        if (CameraManager.IsInCamera(new Vector2(screenPosition.X + 32, screenPosition.Y + 32), 64, 64))
                        {
                            // ?????????
                            spriteBatch.DrawBack(texture, screenPosition, Color.White);
                        }
                    }
                }
            }

            spriteBatch.End();
        }
    }
}
