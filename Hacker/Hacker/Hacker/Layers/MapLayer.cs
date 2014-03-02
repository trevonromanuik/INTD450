using System;
using System.Collections.Generic;
using System.IO;
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

        public MapLayer(string inputFile)
        {
            inputFile = "Content/Levels/" + inputFile + ".txt";
            loadLevelFile(inputFile);
        }

        private void loadLevelFile(string filename)
        {
            string textureFile;
            string line;

            List<int[]> textureArr = new List<int[]>();
            using (StreamReader file = new StreamReader(filename))
            {
                if ((textureFile = file.ReadLine()) != null)
                {
                    tileSet = AssetManager.LoadTexture("Tilesets/" + textureFile);
                    while ((line = file.ReadLine()) != null)
                    {
                        textureArr.Add(line.Split(',').Select(c => Int32.Parse(c.ToString())).ToArray());
                    }
                }
            }

            Tiles = new int[textureArr.Count, textureArr[0].Length];
            for (int i = 0; i < textureArr.Count; i++)
            {
                var array = textureArr[i];
                for (int j = 0; j < textureArr[0].Length; j++)
                {
                    Tiles[i, j] = array[j];
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            int tilesetX = tileSet.Width / 64;
            for (int i = 0, iLength = Tiles.GetLength(0); i < iLength; i++)
            {
                for (int j = 0, jLength = Tiles.GetLength(1); j < jLength; j++)
                {
                    int tile = Tiles[i, j];
                    if (tile != 0)
                    {
                        var screenPosition = CameraManager.GetScreenPosition(new Vector2(64 * j, 64 * i));
                        if (CameraManager.IsInCamera(new Vector2(screenPosition.X + 32, screenPosition.Y + 32), 64, 64))
                        {
                            --tile;
                            int xIndex = tile % tilesetX;
                            int yIndex = tile / tilesetX;

                            Rectangle source = new Rectangle(xIndex * 64, yIndex * 64, 64, 64);
                            Rectangle destination = new Rectangle((int)screenPosition.X, (int)screenPosition.Y, 64, 64);

                            spriteBatch.Draw(tileSet, destination, source, Color.White);
                        }
                    }
                }
            }

            spriteBatch.End();
        }
    }
}
