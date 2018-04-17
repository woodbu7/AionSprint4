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
                },
                ExperiencePoints = 5,
                HealthPoints = 0,
                HasKey = false
            },

            new Civilian
            {
                Id = 2,
                Name = "Timothy Sergent",
                SpaceTimeLocationID = 1,
                Description = "The lead developer of the Stratus Flux Capacitor",
                Messages = new List<string>()
                {
                    "I have to go. Good buy!",
                    "It was always meant for good. We had no idea",
                    "Is that man following you?"
                },
                ExperiencePoints = 10,
                HealthPoints = 0,
                HasKey = false
            },

            new Civilian
            {
                Id = 3,
                Name = "Thorian Diplomat",
                SpaceTimeLocationID = 2,
                Description = "A thorian diplomat dresses in traditional phlox and cords",
                ExperiencePoints = 5,
                HealthPoints = 0,
                HasKey = false
            },

            new Civilian
            {
                Id = 4,
                Name = "General Star",
                SpaceTimeLocationID = 4,
                Description = "A space ship general currently, currently overseaing the training of new pilots.",
                Messages = new List<string>()
                {
                    "Howdy, been on any space ships lately?",
                    "You look like you wouldn't last one day on a space ship."
                },
                ExperiencePoints = 15,
                HealthPoints = 0,
                HasKey = false
            },

            new Civilian
            {
                Id = 5,
                Name = "Merchant",
                SpaceTimeLocationID = 3,
                Description = "A thorian merchant selling Xantorinis, a special fruit only found in the Xantoria.",
                Messages = new List<string>()
                {
                    "What a beautiful day. Perfect day for a Xantorini.",
                    "Have you tried our delicious Xantorinis? They're half off today.",
                    "You look hungry, how about a Xantorini?"
                },
                ExperiencePoints = 10,
                HealthPoints = 10,
                HasKey = false
            },

            new Civilian
            {
                Id = 6,
                Name = "Shaggy old man",
                SpaceTimeLocationID = 2,
                Description = "An old man with shaggy clothes. Looks like a beggar.",
                Messages = new List<string>()
                {
                    "I have seen things. I know things.",
                    "They will come for you. There is only a matter of time.",
                    "Today is tomorrow yesterday."
                },
                ExperiencePoints = 5,
                HealthPoints = 0,
                HasKey = false
            },

            new Civilian
            {
                Id = 7,
                Name = "Luna Tellulah",
                SpaceTimeLocationID = 2,
                Description = "Everyone here knows about Luna Tellulah the fortune teller of the Felandrian Plains.",
                Messages = new List<string>()
                {
                    "Great fortune will come to those who are patient.",
                    "You will be where you won't be and there you will want to be.",
                    "Don't trust anyone who tells you to trust them, no trustworthy person will say that."
                },
                ExperiencePoints = 15,
                HealthPoints = 15,
                HasKey = false
            },

            new Civilian
            {
                Id = 8,
                Name = "Technician",
                SpaceTimeLocationID = 1,
                Description = "A technician workin on a blinking computer.",
                Messages = new List<string>()
                {
                    "Can't talk! Must fix this before...",
                    "You should get out of here, as in far away..."
                },
                ExperiencePoints = 5,
                HealthPoints = 0,
                HasKey = false
            }

        };
        
        
    }

}
