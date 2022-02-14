﻿using System;
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
        public Player(string name, Weapon equippedWeapon, int hitChance, int block, int maxHP, int hp)
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
            return string.Format("\n-=-= PLAYER =-=-\n" +
                "Name: {0}\n" +
                "HP: {1} of {2}\n" +
                "Block: {3}\n" +
                "Base Hit Chance: {4}\n" +
                "Weapon:\n" +
                "{5}\n",
                Name,
                HP,
                MaxHP,
                Block,
                HitChance,
                EquippedWeapon);
        }//end override ToString()
        public override int CalcDamage()
        {
            Random roll = new Random();
            return roll.Next(EquippedWeapon.MinDmg, EquippedWeapon.MaxDmg + 1);
        }

    }//end class
}
