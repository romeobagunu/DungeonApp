using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //FIELDS
        private int _minDmg;

        //PROPS
        public int MaxDmg { get; set; }
        public string Description { get; set; }
        public int MinDmg
        {
            get { return _minDmg; }
            set
            {
                _minDmg = value > 0 && value <= MaxDmg ? value : 1;
            }
        }//end MinDmg prop

        //CTORS
        public Monster(string name, string description, int hp, int maxHP, int hitChance, int block, int minDmg, int maxDmg)
        {
            MaxHP = maxHP;
            MaxDmg = maxDmg;
            Name = name;
            Description = description;
            HitChance = hitChance;
            Block = block;
            HP = hp;
            MinDmg = minDmg;
        }//end FQCTOR

        public Monster() { }//end default ctor

        //METHODS
        public override string ToString()
        {
            return string.Format("\n--== MONSTER ==--\n" +
                "{0}\n" +
                "HP: {1} of {2}\n" +
                "Block: {3}\n" +
                "Hit Chance: {4}\n" +
                "Damage: {5} to {6}\n" +
                "{7}\n",
                Name,
                HP,
                MaxHP,
                HitChance,
                MinDmg,
                MaxDmg,
                Block,
                Description);
        }//end override ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDmg, MaxDmg + 1);
        }//end override CalcDamage()
    }//end class
}//end namespace
