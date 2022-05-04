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
            MaxHP = 50;
            HP = 50;
            HitChance = 90;
            Block = 12;
            MaxDmg = 25;
            MinDmg = 20;
        }

        //METHODS
        public void RollForAttack(Race playerRace)
        {
            ResetStats();
            Random rollDragonAttack = new Random();
            int dragonRoll = rollDragonAttack.Next(1, 11);
            System.Threading.Thread.Sleep(30);
            if (dragonRoll <= 4)
            {
                DoTalonSwipe();
            }
            else if (dragonRoll <= 7)
            {
                DoFlameBreath(playerRace);
            }
            else
            {
                DoCurlUp();
            }
        }
        public void ResetStats()
        {
            MaxDmg = 25;
            Block = 12;
            HitChance = 90;
            MinDmg = 20;
        }
        public void DoTalonSwipe()
        {
            Console.WriteLine("\nThe DRAGON raises its talons to strike you, exposing its underbelly for a split second!");
            Block = 6;
        }
        public void DoFlameBreath(Race playerRace)
        {
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
            Console.WriteLine("\nThe DRAGON reels back, hiding behinds its scales to shield itself from your blow.");
        }
        
    }
}
