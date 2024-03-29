﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using HackerDataTypes;
using Microsoft.Xna.Framework.Audio;

namespace Hacker.Managers
{
    public static class AssetManager
    {
        private static Dictionary<string, Texture2D> _textureList;
        private static Dictionary<string, SpriteFont> _fontList;
        private static Dictionary<string, Message> _messageList;
        private static Dictionary<string, Song> _songList;
        private static Dictionary<string, SoundEffect> _soundEffectList;
        private static Dictionary<string, Email> _emailList;
        private static ContentManager _content;

        public static void Initialize(ContentManager content)
        {
            _textureList = new Dictionary<string, Texture2D>();
            _fontList = new Dictionary<string, SpriteFont>();
            _messageList = new Dictionary<string, Message>();
            _songList = new Dictionary<string, Song>();
            _emailList = new Dictionary<string, Email>();
            _soundEffectList = new Dictionary<string, SoundEffect>();
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
                catch (InvalidOperationException)
                {
                    // there was an issue loading the song
                    // assume it was becuase no audio device is plugged in
                    // don't insert into the song list so that if an audio
                    // device is plugged in later it will start working
                    return null;
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

        public static SoundEffect LoadSoundEffect(string name)
        {
            if (!_soundEffectList.ContainsKey(name))
            {
                try
                {
                    _soundEffectList.Add(name, _content.Load<SoundEffect>(name));
                }
                catch (InvalidOperationException)
                {
                    // there was an issue loading the sound effect
                    // assume it was becuase no audio device is plugged in
                    // don't insert into the song list so that if an audio
                    // device is plugged in later it will start working
                    return null;
                }
            }
            return _soundEffectList[name];
        }
    }
}
