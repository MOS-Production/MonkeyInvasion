using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonkeyInvasion.Classes
{
    class City
    {

        /* Byens navn */
        String Name;


        /*Byens posisjon på kartet*/
        Vector2 Position;

    
        /* Byens nivå (kanskje enum?) Som en int kan level også brukes til å hente 
          hvilken posisjon på spritemap som skal hentes for å vise grafikken til byen 
        */
        int Level;


        /* Id på spilleren som eier byen. Settes til 0 om byen ikke er eid av en spiller. 
           Usikker om dette er best løsning 
        */
        int Owner { get; set; }

    
        /* Byens størrelse satt i antall rader og antall kolonner */
        Vector2 Size;

    
        /* Liste over alle bygninger i en byen. Mulige bedre løsninger? */  
        List<Building> Buildings;



        public City() 
        {
            //Constructor
        }

        public void AddBuilding(int buildingID)
        {
            Building building = new Building(0);
            Buildings.Add(building);
        }


        public Building GetBuildingByPosition(Vector2 position)
        {
            //Returnerer et bygningsobjekt basert på X og Y koordinatene til bygningen
            //Kan også løses med en index
            return new Building(0);
        }


        public void Draw()
        {
            //Tegner byen til skjerm
        }

    }
}