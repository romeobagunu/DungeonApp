using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            bool isBattling = true;
            byte score = 0;

            //Test objects.
            Weapon firstSword = new Weapon("Placeholder Sword", "A default weapon for testing the program.", 3, 8, 10);
            Player player = new Player("Player", firstSword, 70, 5, 40, 40);

            Monster Bard = new Monster("Screecher", "A nimble and frail creature with long hair. It carries a wooden bludgeon that lets out a whimsical noise as it strikes.", 5, 5, 80, 10, 3, 5);

            Monster Dwarf = new Monster("Digger", "Stout, grizly, and foul-scented.", 15, 15, 50, 30, 5, 8);

            Monster Wizard = new Monster("Wizard", "White hair and wrinkled skin give the thin creature an air of wisdom. It leans upon a branch that glows faintly.", 20, 20, 90, 0, 8, 20);

            Monster[] monsters1 = new Monster[] { Bard, Bard, Bard };

            Monster[] monsters2 = new Monster[] { Dwarf, Dwarf, Dwarf };

            Monster[] bosses = new Monster[] { Wizard, Wizard };

            Monster opponent;

            do
            {
                Console.WriteLine("Welcome to the Dungeon.");

                if (score < 8)
                {
                    if (score > 6)
                    {
                        Console.WriteLine("Welcome to the boss room.");
                        Console.WriteLine("Thou wilt face a hero or a wizard.");
                        Random roll = new Random();
                        opponent = bosses[roll.Next(1, 3)];
                    }
                    else if (score > 3)
                    {
                        Console.WriteLine("Welcome to Lvl 2 Rooms.");
                        Console.WriteLine("Thou wilt face a Dwarf, Elf, or Knight.");
                        Random roll = new Random();
                        opponent = monsters2[roll.Next(1, 4)];
                    }
                    else
                    {
                        Console.WriteLine("Welcome to Lvl 1 Rooms.");
                        Console.WriteLine("Thou wilt face a Squire, Bard, or Halfling.");
                        Random roll = new Random();
                        opponent = monsters1[roll.Next(1, 4)];
                    }

                    do
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
                                Battle.DoBattle(player, opponent);
                                if (opponent.HP <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(opponent.Name + " has been slain.\n" +
                                        "Victory is thine!");
                                    Console.ResetColor();
                                    score++;
                                    isBattling = false;
                                }
                                break;
                            case ConsoleKey.R:
                                Console.WriteLine("Thou attemptest to flee...");
                                if (score < 7)
                                {
                                    Console.WriteLine("But thine enemy attacketh thee!");
                                    Battle.DoAttack(opponent, player);
                                    isBattling = false;
                                }
                                if (score > 6)
                                {
                                    Console.WriteLine("...But thou canst not run. This battle hath always been thine fate.");
                                }
                                break;
                            case ConsoleKey.P:
                                Console.Clear();
                                Console.WriteLine(player);
                                break;
                            case ConsoleKey.M:
                                Console.Clear();
                                Console.WriteLine(opponent);
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
                if (player.HP <= 0)
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
            Console.WriteLine("Score: " + score);
        }//end Main()
    }//end class
}//namespace
