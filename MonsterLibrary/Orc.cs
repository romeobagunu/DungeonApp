using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace MonsterLibrary
{
    public class Orc : Monster
    {
        //FIELDS

        //PROPS
        public bool IsEquipped { get; set; }
        public bool IsThickSkinned { get; set; }

        //CTORS
        public Orc(string name, string description, int hp, int maxHP, int hitChance, int block, int minDmg, int maxDmg, bool isEquipped, bool isThickSkinned) : base(name, description, hp, maxHP, hitChance, block, minDmg, maxDmg)
        {
            IsEquipped = isEquipped;
            if (IsEquipped)
            {
                HitChance -= 10;
                MinDmg += 3;
                MaxDmg += 4;
                Block += 1;
            }
            if (IsThickSkinned)
            {
                Block += 3;
            }
        }

        public Orc()
        {
            MaxHP = 12;
            MaxDmg = 12;
            Name = "Orc";
            Description = "A brutish creature with yellow eyes and small horns. It clenches its fists. Those knuckles could pack a serious punch!";
            HitChance = 70;
            Block = 0;
            HP = 12;
            MinDmg = 8;
            IsEquipped = false;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + (IsEquipped ? "\nThis orc is equipped with armor, a shield, and a club." : "");
        }//end override ToString()
    }//end class
}//end namespace
