using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    public static partial class UniverseObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                Id = 1,
                Name = "Man with Stripped Hat",
                SpaceTimeLocationID = 2,
                Description = "A tall man in baggy pants with a red, pin stripped hat",
                Messages = new List<string>()
                {
                    "Grettings stranger. You are not from these parts as I can see",
                    "You will find what you are looking ofr with the Pink Gorilla",
                    "I once attented the Academy. The felt I needed more candles"
                }
            },

            new Civilian
            {
                Id = 2,
                Name = "Timothy Sergent",
                SpaceTimeLocationID = 1,
                Description = "The lead developer of the Stratus Flux Capacitor",
                Messages = new List<string>()
                {
                    "I have to go. Godd buy!",
                    "It was always meant for good. We had no idea",
                    "Is that man following you?"
                }
            },

            new Civilian
            {
                Id = 3,
                Name = "Thorian Diplomat",
                SpaceTimeLocationID = 2,
                Description = "A thorian diplomat dresses in traditional phlox and cords"
            }
        };
        
        
    }

}
