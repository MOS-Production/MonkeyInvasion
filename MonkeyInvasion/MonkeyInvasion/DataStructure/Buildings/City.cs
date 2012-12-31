using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonkeyInvasion.DataStructure.Buildings
{
    class City
    {

        /* Byens navn */
        String Name = "";


        /* Byens posisjon på kartet */
        Vector2 Position;

    
        /* 
         * Byens nivå (kanskje enum?) Som en int kan level også brukes til å hente 
         * hvilken posisjon på spritemap som skal hentes for å vise grafikken til byen 
         */
        int Level = -1;


        /* 
         * Id på spilleren som eier byen. Settes til 0 om byen ikke er eid av en spiller. 
         * Usikker om dette er best løsning 
         */
        int Owner { get; set; }

    
        /* Byens størrelse satt i antall rader og antall kolonner */
        Vector2 Size;

    
        /* Liste over alle bygninger i en byen. Mulige bedre løsninger? */
        List<Building> Buildings = new List<Building>();


        public City() 
        {
            //Constructor
        }


        public void AddNewBuilding(Building building)
        {            
            Buildings.Add(building);
        }

        public void Draw()
        {
            //Tegner byen til skjerm
        }

    }
}