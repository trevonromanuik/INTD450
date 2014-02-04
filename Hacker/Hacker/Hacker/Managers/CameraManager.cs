using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Screens;

namespace Hacker.Managers
{
    public static class CameraManager
    {
        public static GameObject CameraTarget { get; set; }

        public static Vector2 GetScreenPosition(Vector2 position)
        {
            var mapLayer = GameScreen.Level.GetLayer<MapLayer>();
            int width = mapLayer.Tiles.GetLength(1) * 64;
            int height = mapLayer.Tiles.GetLength(0) * 64;

            var targetPosition = CameraTarget.GetComponent<Position>();
            var cameraPosition = new Vector2(targetPosition.X, targetPosition.Y);
            
            int xDepth = (int)cameraPosition.X + 320 - width;
            if (xDepth > 0)
            {
                cameraPosition.X -= xDepth;
            }
            else
            {
                xDepth = (int)cameraPosition.X - 320;
                if (xDepth < 0)
                {
                    cameraPosition.X -= xDepth;
                }
            }

            int yDepth = (int)cameraPosition.Y + 256 - height;
            if (yDepth > 0)
            {
                cameraPosition.Y -= yDepth;
            }
            else
            {
                yDepth = (int)cameraPosition.Y - 256;
                if (yDepth < 0)
                {
                    cameraPosition.Y -= yDepth;
                }
            }

            return new Vector2(position.X - cameraPosition.X + 320, position.Y - cameraPosition.Y + 256);
        }

        public static bool IsInCamera(Vector2 position, int width, int height)
        {
            return position.X + width / 2 > 0
                && position.X - width / 2 < 640
                && position.Y + height / 2 > 0
                && position.Y - height / 2 < 512;
        }
    }
}
