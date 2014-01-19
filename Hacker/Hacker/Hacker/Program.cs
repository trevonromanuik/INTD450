using System;

namespace Hacker
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Hacker game = new Hacker())
            {
                game.Run();
            }
        }
    }
#endif
}

