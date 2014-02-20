using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace Hacker.Managers
{
    public static class SoundManager
    {
        private static string currentMusicName = null;

        public static void PlayMusic(string name)
        {
            if (currentMusicName == name)
            {
                return;
            }

            Song music = AssetManager.LoadSong("Music/" + name);
            if (music != null)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(music);
                currentMusicName = name;
            }
        }

        public static void StopAmbientMusic()
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
    }
}
