using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Layers
{
    class CollisionLayer : Layer
    {
        public int[,] Collisions { get; private set; }

        public CollisionLayer(string collisionFile)
        {
            collisionFile = "Content/Levels/" + collisionFile + ".txt";
            loadCollisionFile(collisionFile);
        }

        private void loadCollisionFile(string filename)
        {
            string textureFile;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            List<int[]> textureArr = new List<int[]>();
            while ((line = file.ReadLine()) != null)
            {
                textureArr.Add(line.Split(',').Select(c => Int32.Parse(c.ToString())).ToArray());
            }
            Collisions = new int[textureArr.Count, textureArr[0].Length];
            for (int i = 0; i < textureArr.Count; i++)
            {
                var array = textureArr[i];
                for (int j = 0; j < textureArr[0].Length; j++)
                {
                    Collisions[i, j] = array[j];
                }
            }
        }
    }
}
