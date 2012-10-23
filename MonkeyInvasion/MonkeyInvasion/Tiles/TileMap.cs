using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyInvasion.Tiles
{
    class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 50;
        public int MapHeight = 50;

        Random rand = new Random();

        public TileMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    
                    thisRow.Columns.Add(new MapCell(rand.Next(4)));
                }
                Rows.Add(thisRow);
            }
        }


    }

    class MapRow
    {
        public List<MapCell> Columns = new List<MapCell>();
    }
}
