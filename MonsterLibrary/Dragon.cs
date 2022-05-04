using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Dragon : Monster
    {
        //FIELDS

        //PROPS

        //CTORS
        public Dragon()
        {
            Name = "DRAGON";
            Description = "A titan of the ancient world. Not many live to this day, but the few that remain are tough, terrifying creatures with glittering scales and a sinister gaze. Its talons can shred through the toughest armor, and if you fail to evade its flames, you're toast.";
            HP = 50;
            MaxHP = 50;
            HitChance = 90;
            Block = 12;
            MinDmg = 20;
            MaxDmg = 25;
        }

        //METHODS
        public void ResetStats()
        {
            MaxDmg = 25;
            Block = 12;
            HitChance = 90;
            MinDmg = 20;
        }
        public void DoTalonSwipe()
        {
            ResetStats();
            Console.WriteLine("\nThe DRAGON raises its talons to strike you, exposing its underbelly for a split second!");
            Block = 6;
        }
        public void DoFlameBreath(Race playerRace)
        {
            ResetStats();
            Console.WriteLine("\nThe DRAGON rears its head far back. But as the deadly flames build behind its teeth, you catch a glimpse at a vulnerability in its scales. Go in for a CRITICAL HIT!");
            Block = 0;
            MaxDmg = 35;
            MinDmg = 30;
            switch (playerRace)
            {
                case Race.Human:
                    HitChance = 50;
                    break;
                case Race.Dwarf:
                    HitChance = 66;
                    break;
                case Race.Elf:
                    HitChance = 33;
                    break;
            }
        }
        public void DoCurlUp()
        {
            ResetStats();
            Console.WriteLine("\nThe DRAGON reels back, hiding behinds its scales to shield itself from your blow.");
        }
        
    }
}
