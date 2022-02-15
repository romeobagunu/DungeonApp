using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace MonsterLibrary
{
    public class Goblin : Monster
    {
        //FIELDS

        //PROPS
        public bool IsEquipped { get; set; }

        //CTORS
        public Goblin(string name, string description, int hp, int maxHP, int hitChance, int block, int minDmg, int maxDmg, bool isEquipped) : base(name, description, hp, maxHP, hitChance, block, minDmg, maxDmg)
        {
            IsEquipped = isEquipped;
            if (IsEquipped)
            {
                HitChance += 10;
                MinDmg += 2;
                MaxDmg += 3;
                Block += 2;
            }
        }

        public Goblin()
        {
            MaxHP = 8;
            MaxDmg = 8;
            Name = "Gremlin";
            Description = "A mischievous little creature with large eyes and sharp teeth.";
            HitChance = 80;
            Block = 0;
            HP = 8;
            MinDmg = 6;
            IsEquipped = false;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + (IsEquipped ? "\nThis goblin is equipped with basic armor, a wooden shield, and a club." : "");
        }
    }//end class
}//end namespace
