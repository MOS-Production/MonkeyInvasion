using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyInvasion.EventHandlers
{
    public static class MonkeyEvents
    {

        //TODO: Add access to the various ScreenManager etc etc:)

        public static void TestButtonClickEvent(object sender, EventArgs e)
        {
            
            Console.WriteLine("BUTTON CLICKED!");
        }


    }
}
