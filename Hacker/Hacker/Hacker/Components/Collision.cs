using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Extensions;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;

namespace Hacker.Components
{
    class Collision : Component
    {
        const int tileDimension = 64;

        public Vector2 CheckCollision(Vector2 position, int width, int height)
        {
            MapLayer mapLayer = GameScreen.Level.GetLayer<MapLayer>();
            var collisions = new List<Vector2>();
            
            // Determine which tiles the player currently occupies.
            int minI = Math.Max(0, (int)Math.Floor((position.Y - (height / 2)) / tileDimension));
            int maxI = Math.Min(mapLayer.Tiles.GetLength(0) - 1, (int)Math.Floor((position.Y + (height / 2)) / tileDimension));
           

            int minJ = Math.Max(0, (int)Math.Floor((position.X - (width / 2)) / tileDimension));
            int maxJ = Math.Min(mapLayer.Tiles.GetLength(1) - 1, (int)Math.Floor((position.X + (width / 2)) / tileDimension));

            // Get the player's bounding box.
            Rectangle bounds = new Rectangle((int)position.X - (width / 2), (int)position.Y - (height / 2), width, height);

            // For each tile the player is currently on...
            for (int i = minI; i <= maxI; ++i)
            {
                for (int j = minJ; j <= maxJ; j++)
                {
                    // Check to see if the tile is an area boundary
                    if (mapLayer.Tiles[i, j] == 0)
                    {
                        // Get the tile boundaries
                        Rectangle tileBounds = new Rectangle(j * tileDimension, i * tileDimension, tileDimension, tileDimension);
                        Vector2 depth = bounds.GetIntersectionDepth(tileBounds);
                        if (depth != Vector2.Zero)
                        {
                            collisions.Add(depth);
                        }
                    }
                }
            }

            switch (collisions.Count)
            {
                // We're in a corner.
                case 3:
                    foreach (var collision in collisions)
                    {
                        if (Math.Abs(collision.X) == Math.Abs(collision.Y))
                        {
                            bounds.Y += (int)collision.Y;
                            position.Y += collision.Y;
                            bounds.X += (int)collision.X;
                            position.X += collision.X;
                        }
                    }
                    break;
                // We've hit a wall. Figure out which wall is adjacent to us and move away.
                case 2:
                    if (collisions[0].X == collisions[1].X)
                    {
                        bounds.X += (int)collisions[0].X;
                        position.X += collisions[0].X;
                    }
                    else
                    {
                        bounds.Y += (int)collisions[0].Y;
                        position.Y += collisions[0].Y;
                    }
                    break;
                // We've hit a single brick. Back up.
                case 1:
                    if (Math.Abs(collisions[0].X) < Math.Abs(collisions[0].Y))
                    {
                        bounds.X += (int)collisions[0].X;
                        position.X += collisions[0].X;
                    }
                    else
                    {
                        bounds.Y += (int)collisions[0].Y;
                        position.Y += collisions[0].Y;
                    }
                    break;
            }

            return position;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}