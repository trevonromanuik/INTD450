using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using HackerDataTypes;

namespace Hacker.Managers
{
    public static class AssetManager
    {
        private static Dictionary<string, Texture2D> _textureList;
        private static Dictionary<string, SpriteFont> _fontList;
        private static Dictionary<string, Message> _messageList;
        private static Dictionary<string, Song> _songList;
        private static Dictionary<string, Email> _emailList;
        private static ContentManager _content;

        public static void Initialize(ContentManager content)
        {
            _textureList = new Dictionary<string, Texture2D>();
            _fontList = new Dictionary<string, SpriteFont>();
            _messageList = new Dictionary<string, Message>();
            _songList = new Dictionary<string, Song>();
            _emailList = new Dictionary<string, Email>();
            _content = content;
        }

        public static Texture2D LoadTexture(string name)
        {
            if (!_textureList.ContainsKey(name))
            {
                _textureList.Add(name, _content.Load<Texture2D>(name));
            }
            return _textureList[name];
        }

        public static SpriteFont LoadFont(string name)
        {
            if (!_fontList.ContainsKey(name))
            {
                _fontList.Add(name, _content.Load<SpriteFont>(name));
            }
            return _fontList[name];
        }

        public static Message LoadMessage(string name)
        {
            if (!_messageList.ContainsKey(name))
            {
                _messageList.Add(name, _content.Load<Message>(name));
            }
            return _messageList[name];
        }

        public static Song LoadSong(string name)
        {
            if (!_songList.ContainsKey(name))
            {
                try
                {
                    _songList.Add(name, _content.Load<Song>(name));
                }
                catch (InvalidOperationException ex)
                {
                    _songList.Add(name, new Song());
                }
            }
            return _songList[name];
        }

        public static Email LoadEmail(string name)
        {
            if (!_emailList.ContainsKey(name))
            {
                _emailList.Add(name, _content.Load<Email>("Emails/"+name));
            }
            return _emailList[name];
        }
    }
}
