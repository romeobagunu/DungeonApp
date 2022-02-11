using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //FIELDS

        //PROPS
        public Weapon EquippedWeapon { get; set; }

        //CTORS
        public Player (string name, Weapon equippedWeapon, int hitChance, int block, int maxHP, int hp)
        {
            MaxHP = maxHP;
            Name = name;
            EquippedWeapon = equippedWeapon;
            HitChance = hitChance;
            Block = block;
            HP = hp;
        }//end FQCTOR

        //METHODS
        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n" +
                "HP: {1} of {2}\n" +
                "Base Hit Chance: {3}\n" +
                "Weapon:\n" +
                "{4}\n" +
                "Block: {5}\n",
                Name,
                HP,
                MaxHP,
                HitChance,
                EquippedWeapon,
                Block);
        }//end override ToString()
    }//end class
}//end namespace
