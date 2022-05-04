using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Troll : Orc
    {
        //FIELDS

        //PROPS

        //CTORS
        public Troll()
        {
            Name = "TROLL";
            Description = "A fierce brute of the caves. They're slow but tough and deliver crushing blows. If you're quick, you've got a good shot at evading him. But be cautious - should the battle drag on, your weariness could prove deadly.";
            MaxHP = 30;
            HP = 30;
            HitChance = 30;
            Block = 2;
            MaxDmg = 25;
            MinDmg = 20;
            IsEquipped = false;
            IsThickSkinned = true;
        }

        //METHODS
        public void TirePlayer(Race playerRace)
        {
            switch (playerRace)
            {
                case Race.Human:
                    HitChance += 10;
                    break;
                case Race.Dwarf:
                    HitChance += 15;
                    break;
                case Race.Elf:
                    HitChance += 5;
                    break;
            }
        }
    }
}
