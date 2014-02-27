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
    class MapLayer : Layer
    {
        public int[,] Tiles { get; set; }

        Texture2D tileSet; 
        Texture2D tileTexture;
        Texture2D wallTexture;

        public MapLayer(string inputFile)
        {
            tileTexture = AssetManager.LoadTexture("tile");
            wallTexture = AssetManager.LoadTexture("wall");
            loadLevelFile(inputFile);
        }

        private void loadLevelFile(string filename)
        {
            string textureFile;
            string line;
            
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            if ((textureFile = file.ReadLine()) != null)
            {
                List<int[]> textureArr = new List<int[]>();
                while((line = file.ReadLine()) != null)
                {
                    textureArr.Add(line.Split(',').Select(c => Int32.Parse(c.ToString())).ToArray());
                }
                Tiles = new int[textureArr.Count, textureArr[0].Length];
                for(int i = 0; i < textureArr.Count; i++)
                {
                    var array = textureArr[i];
                    for(int j = 0; j < textureArr[0].Length; j++) 
                    {
                        Tiles[i,j] = array[j];
                    }
                }
            }
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
                            spriteBatch.Draw(texture, screenPosition, Color.White);
                        }
                    }
                }
            }
            spriteBatch.End();
        }
    }
}
