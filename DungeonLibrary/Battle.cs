using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Battle
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random d100 = new Random();
            int roll = d100.Next(1, 101);

            int attackerHitChance = attacker.CalcHitChance();

            System.Threading.Thread.Sleep(30);

            if (roll <= attackerHitChance)
            {
                int dmgDealt = attacker.CalcDamage();
                dmgDealt -= defender.Block;

                System.Threading.Thread.Sleep(30);

                if (dmgDealt > 0)
                {
                    defender.HP -= dmgDealt;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} hit {1} for {2} damage!",
                        attacker.Name,
                        defender.Name,
                        dmgDealt);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("{0} hit dealt 0 damage to {1}. The blow was blocked!",
                    attacker.Name,
                    defender.Name);
                }
            }
            else
            {
                Console.WriteLine(attacker.Name + " missed!");
            }
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);
            if (monster.HP > 0)
            {
                DoAttack(monster, player);
            }
        }//end DoBattle()
    }//end class
}//end namespace
