using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using Microsoft.Xna.Framework.Graphics;

namespace Hacker.Layers
{
    class AnimatedMapLayer : MapLayer
    {
        private string[] files;

        private int counter;

        private Timer timer;

        public AnimatedMapLayer(string[] inputFiles, int interval) :
            base(inputFiles[0])
        {
            files = inputFiles;
            counter = 0;
            timer = new Timer(interval * 1000);
            timer.Elapsed += new ElapsedEventHandler(changeMapEvent);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void changeMapEvent(object source, ElapsedEventArgs e)
        {
            counter++;
            if (counter == files.Length)
            {
                counter = 0;
            }

            base.loadLevelFile("Content/Levels/"+files[counter]+".txt");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
