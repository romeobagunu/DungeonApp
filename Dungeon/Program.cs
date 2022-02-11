using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            bool isBattling = true;
            byte score = 0;
            byte playerLife = 10;//Temporary placeholder
            do
            {
                Console.WriteLine("Welcome to the Dungeon.");

                if (score < 8)
                {
                    if (score > 6)
                    {
                        Console.WriteLine("Welcome to the boss room.");
                        Console.WriteLine("Thou wilt face a hero or a wizard.");
                    }
                    else if (score > 3)
                    {
                        Console.WriteLine("Welcome to Lvl 2 Rooms.");
                        Console.WriteLine("Thou wilt face a Dwarf, Elf, or Knight.");
                    }
                    else
                    {
                        Console.WriteLine("Welcome to Lvl 1 Rooms.");
                        Console.WriteLine("Thou wilt face a Squire, Bard, or Halfling.");
                    }

                    do//Menu
                    {
                        Console.WriteLine("Choosest thou an action:\n" +
                            "A) Attack\n" +
                            "R) Run Away\n" +
                            "P) View Player Stats\n" +
                            "M) View Monster Stats\n" +
                            "Q) Quit\n");
                        ConsoleKey menuChoice = Console.ReadKey(false).Key;
                        Console.Clear();
                        switch (menuChoice)
                        {
                            case ConsoleKey.A:
                                //Combat code here.
                                score++;
                                Console.WriteLine("Victory is thine.");
                                isBattling = false;
                                break;
                            case ConsoleKey.R:
                                Console.WriteLine("Thou attemptest to flee...");
                                if (score < 7)
                                {
                                    Console.WriteLine("But thine enemy striketh thee!");
                                    isBattling = false;
                                }
                                if (score > 6)
                                {
                                    Console.WriteLine("...But thou canst not run. This battle hath always been thine fate.");
                                    isBattling = true;
                                }
                                break;
                            case ConsoleKey.P:
                                Console.Clear();
                                Console.WriteLine("Display Player Stats.");
                                break;
                            case ConsoleKey.M:
                                Console.Clear();
                                Console.WriteLine("Display Monster Stats.");
                                break;
                            case ConsoleKey.Q:
                                isBattling = false;
                                isPlaying = false;
                                break;
                            default:
                                Console.WriteLine("!! Invalid input, please try again. !!");
                                break;
                        }
                    } while (isPlaying && isBattling);
                }//end if - Game Complete checker.
                if (playerLife == 0)
                {
                        do
                        {
                            Console.WriteLine("Game Over.");
                            Console.Write("Would you like to play again?\n" +
                                "R) Restart\n" +
                                "Q) Quit\n");
                            ConsoleKey gameOverChoice = Console.ReadKey(false).Key;
                            Console.Clear();
                            switch (gameOverChoice)
                            {
                                case ConsoleKey.R:
                                    Console.Clear();
                                     score = 0;
                                    break;
                                case ConsoleKey.Q:
                                    Console.Clear();
                                    isPlaying = false;
                                    break;
                                default:
                                    Console.WriteLine("!! Invalid input, please try again. !!");
                                    break;
                            }//end switch
                        } while (isPlaying);//end do while - Game Over Menu
                }
                if (score == 8)
                {
                    Console.Write("Wilt thou walk into the light?\n" +
                                "L) Leave the Dungeon.\n" +
                                "S) Stay in the Dungeon.\n");
                    ConsoleKey gameOverChoice = Console.ReadKey(false).Key;
                    Console.Clear();
                    switch (gameOverChoice)
                    {
                        case ConsoleKey.L:
                            Console.Clear();
                            Console.WriteLine("A new beginning waiteth upon thee.");
                            isPlaying = false;
                            break;
                        case ConsoleKey.S:
                            isPlaying = true;
                            score = 0;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("!! Invalid input, please try again. !!");
                            break;
                    }//end switch
                }
            } while (isPlaying);

            Console.WriteLine("Thankest thou for playing!");
            Console.WriteLine("Final score: " + score);
        }//end Main()
    }//end class
}//namespace
