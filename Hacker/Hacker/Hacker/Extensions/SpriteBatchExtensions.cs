using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hacker.Extensions
{
    static class SpriteBatchExtensions
    {
        public static void DrawZ(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Color color, float z)
        {
            spriteBatch.Draw(texture, position, null, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, z);
        }

        public static void DrawZ(this SpriteBatch spriteBatch, Texture2D texture, Rectangle r1, Rectangle? r2, Color color, float z)
        {
            spriteBatch.Draw(texture, r1, r2, color, 0.0f, Vector2.Zero, SpriteEffects.None, z);
        }

        public static void DrawFront(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, position, null, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 1.0f);
        }

        public static void DrawFront(this SpriteBatch spriteBatch, Texture2D texture, Rectangle r1, Rectangle? r2, Color color)
        {
            spriteBatch.Draw(texture, r1, r2, color, 0.0f, Vector2.Zero, SpriteEffects.None, 1.0f);
        }

        public static void DrawBack(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, position, null, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);
        }

        public static void DrawBack(this SpriteBatch spriteBatch, Texture2D texture, Rectangle r1, Rectangle? r2, Color color)
        {
            spriteBatch.Draw(texture, r1, r2, color, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
        }

        public static void DrawStringFront(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, text, position, color, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 1.0f);
        }
    }
}
