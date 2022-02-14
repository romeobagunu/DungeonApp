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

        //CTORS
        public Goblin(string name, string description, int hp, int maxHP, int hitChance, int block, int minDmg, int maxDmg) : base(name, description, hp, maxHP, hitChance, block, minDmg, maxDmg)
        {

        }

        public Goblin()
        {
            MaxHP = 8;
            MaxDmg = 3;
            Name = "Gremlin";
            Description = "A mischievous little creature with large eyes and sharp teeth.";
            HitChance = 60;
            Block = 0;
            HP = 8;
            MinDmg = 2;
        }

        //Methods
        public override string ToString()
        {
            return string.Format(base.ToString());
        }

    }//end class
}//end namespace
