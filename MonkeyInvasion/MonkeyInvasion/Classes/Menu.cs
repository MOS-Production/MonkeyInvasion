using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonkeyInvasion.Classes
{
    class Menu
    {

		/* Contains all of the items in the menu */
		List<String> MenuItems;

		Color ActiveColor;
		Color MenuColor;

		public Menu() 
		{
			//Constructor
		}

		public int GetNumberOfMenuItems() 
		{
			return MenuItems.Count();
		}

	}

}