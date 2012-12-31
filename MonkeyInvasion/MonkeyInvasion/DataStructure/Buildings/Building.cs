using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonkeyInvasion.DataStructure.Buildings
{
    class Building
    {

        int buildingId;

        BuildingType buildingType;


        public Building(int buildingId, BuildingType buildingType)
        {
            this.buildingId = buildingId;
            this.buildingType = buildingType;
        }

    }
}
