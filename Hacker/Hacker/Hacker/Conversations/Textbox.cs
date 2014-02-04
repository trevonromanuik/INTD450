using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Managers;

namespace Hacker.Conversations
{
    class Textbox
    {
        int _x, _y, _width, _height;

        Texture2D _textboxTexture;

        public Textbox(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;

            _textboxTexture = AssetManager.LoadTexture("textbox");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //left
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x, _y + 8, 8, _height - 16), new Rectangle(0, 8, 8, 1), Color.White);

            //top
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x + 8, _y, _width - 16, 8), new Rectangle(8, 0, 1, 8), Color.White);

            //right
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x + _width - 8, _y + 8, 8, _height - 16), new Rectangle(9, 8, 8, 1), Color.White);

            //bottom
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x + 8, _y + _height - 8, _width - 16, 8), new Rectangle(8, 9, 1, 8), Color.White);

            //top-left
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x, _y, 8, 8), new Rectangle(0, 0, 8, 8), Color.White);

            //top-right
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x + _width - 8, _y, 8, 8), new Rectangle(9, 0, 8, 8), Color.White);

            //bottom-right
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x + _width - 8, _y + _height - 8, 8, 8), new Rectangle(9, 9, 8, 8), Color.White);

            //bottom-left
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x, _y + _height - 8, 8, 8), new Rectangle(0, 9, 8, 8), Color.White);

            //center
            spriteBatch.Draw(_textboxTexture, new Rectangle(_x + 8, _y + 8, _width - 16, _height - 16), new Rectangle(8, 8, 1, 1), Color.White);
        }
    }
}
