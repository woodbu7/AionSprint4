﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    public class Civilian : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public List<string> Messages { get; set; }
        public int ExperiencePoints { get; set; }
        public int HealthPoints { get; set; }
        public bool HasKey { get; set; }

        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns></returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return $"My name is {base.Name} and I am a {base.Race.ToString()}";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns></returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
