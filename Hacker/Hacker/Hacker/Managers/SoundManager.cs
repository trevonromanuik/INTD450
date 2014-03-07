using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Hacker.Managers
{
    public static class SoundManager
    {
        private static Dictionary<string, SoundEffectInstance> sounds;
        private static string currentMusicName;

        static SoundManager()
        {
            sounds = new Dictionary<string, SoundEffectInstance>();
            currentMusicName = null;
        }

        public static void PlayMusic(string name)
        {
            if (currentMusicName == name)
            {
                return;
            }

            if(MediaPlayer.State == MediaState.Playing)
            {
                StopMusic();
            }

            Song music = AssetManager.LoadSong("Music/" + name);
            if (music != null)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(music);
                currentMusicName = name;
            }
        }

        public static void PlaySound(string name, bool pauseMusic, bool looping = false)
        {
            if (!sounds.ContainsKey(name))
            {
                var sound = AssetManager.LoadSoundEffect("SoundEffects/" + name);
                if(sound != null)
                {
                    var soundInstance = sound.CreateInstance();
                    soundInstance.IsLooped = looping;
                    sounds.Add(name, soundInstance);
                }
                else
                {
                    return;
                }
            }

            var instance = sounds[name];

            instance.Play();
            
            if (pauseMusic && MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
                SpinWait sw = new SpinWait();
                while (instance.State != SoundState.Stopped)
                {
                    sw.SpinOnce();
                }

                MediaPlayer.Resume();
            }
        }

        public static void StopMusic()
        {
            if (MediaPlayer.State == MediaState.Stopped)
            {
                return;
            }
            else
            {
                MediaPlayer.Stop();
            }
        }

        public static void StopAllSounds()
        {
            foreach(var sound in sounds) {
                sound.Value.Stop();
            }
        }
    }
}
