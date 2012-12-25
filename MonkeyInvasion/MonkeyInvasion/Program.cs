using System;

namespace MonkeyInvasion
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MonkeyInvasionGame game = new MonkeyInvasionGame())
            {
                game.Run();
            }
        }
    }
#endif
}

