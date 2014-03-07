using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Components
{
    class Boundary : Sprite
    {
        public Boundary(int width, int height) :
            base(null)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            return;
        }
    }
}
