using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyInvasion.Tiles
{
    class MapCell
    {
        public int TileID { get; set; }

        public MapCell(int tileId)
        {
            TileID = tileId;
        }

    }
}
