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
            bool isCustomizing = true;
            bool isBattling = true;
            bool isRestarting = false;

            byte score = 0;

            Weapon starterSword = new Weapon("Sword", "A blade that looks dull. It ain't much, but it'll get the job done.", 3, 6, 0);
            Weapon starterJavelin = new Weapon("Javelin", "An agile and dependable weapon with a long reach.", 2, 5, 15);
            Weapon starterAxe = new Weapon("Axe", "A heavy tool for a hard worker. If your blow lands, it could do some serious damage.", 5, 10, -15);

            Player player = new Player("Player", Race.Human, starterSword, 70, 5, 40, 40);

            do
            {
                Console.WriteLine("Please enter your name...\n");
                player.Name = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Welcome, " + player.Name + "!\n");

                do
                {
                    Console.WriteLine("Please select a race:\n" +
                        "1) Human\n" +
                        "2) Elf\n" +
                        "3) Dwarf\n");
                    ConsoleKey raceChoice = Console.ReadKey(false).Key;
                    Console.Clear();
                    switch (raceChoice)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.H:
                            isCustomizing = false;
                            player.PlayerRace = Race.Human;
                            player.EquippedWeapon = starterSword;
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.E:
                            isCustomizing = false;
                            player.PlayerRace = Race.Elf;
                            player.EquippedWeapon = starterJavelin;
                            player.MaxHP = 90;
                            player.HP = 90;
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.D:
                            player.PlayerRace = Race.Dwarf;
                            player.EquippedWeapon = starterAxe;
                            player.MaxHP = 60;
                            player.HP = 60;
                            player.Block = 7;
                            isCustomizing = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("!! Invalid input, please try again. !!\n");
                            break;
                    }
                } while (isCustomizing);//end do while - Customization

                Console.Clear();

                Monster opponent = new Monster("Placeholder Monster", "Placeholder for testing.", 1, 1, 0, 0, 0, 0);

                do
                {
                    Console.WriteLine(GetRoom());
                    Console.WriteLine("\n!! You encounter a " + opponent.Name + " !!\n");
                    do
                    {
                        Console.WriteLine("Choose an action:\n" +
                            "1) Attack\n" +
                            "2) Run Away\n" +
                            "3) View Player Stats\n" +
                            "4) View Monster Stats\n" +
                            "Q) Quit\n");
                        ConsoleKey menuChoice = Console.ReadKey(false).Key;
                        Console.Clear();
                        switch (menuChoice)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.D1:
                                Battle.DoBattle(player, opponent);
                                if (opponent.HP <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(opponent.Name + " has been slain.\n" +
                                        "Victory!\n");
                                    Console.ResetColor();
                                    Console.WriteLine("Press any key to continue to the next room.");
                                    Console.ReadKey(false);
                                    score++;
                                    isBattling = false;
                                }
                                break;
                            case ConsoleKey.R:
                            case ConsoleKey.D2:
                                Console.WriteLine("You attempt to flee...\n");
                                if (score < 12)
                                {
                                    Console.WriteLine("But " + opponent.Name + "attacks you as you run!\n");
                                    Battle.DoAttack(opponent, player);
                                    isBattling = false;
                                }
                                else
                                {
                                    Console.WriteLine("...But you can't run. This battle is your destiny.\n");
                                }
                                break;
                            case ConsoleKey.P:
                            case ConsoleKey.D3:
                                Console.Clear();
                                Console.WriteLine(player);
                                break;
                            case ConsoleKey.M:
                            case ConsoleKey.D4:
                                Console.Clear();
                                Console.WriteLine(opponent);
                                break;
                            case ConsoleKey.Q:
                                isBattling = false;
                                isPlaying = false;
                                break;
                            default:
                                Console.WriteLine("!! Invalid input, please try again. !!\n");
                                break;
                        }
                    } while (isPlaying && isBattling);//end if Action Menu

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
                                    player.Name = "Player";
                                    player.PlayerRace = Race.Human;
                                    player.EquippedWeapon = starterSword;
                                    player.HitChance = 70;
                                    player.Block = 5;
                                    player.MaxHP = 40;
                                    player.HP = 40;
                                    score = 0;
                                    isRestarting = true;
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
                    }//end if - Game Over Screen
                } while (isPlaying);//end - Gameplay Loop
            } while (!isRestarting);//end - Game Loop

             Console.WriteLine("Thank you for playing!\n");
             Console.WriteLine("Score: " + score);

        }//end Main()

        public static string GetRoom()
        {
            string[] rooms =
            {
            "A large forge squats against the far wall of this room, and coals glow dimly inside. Before the forge stands a wide block of iron with a heavy-looking hammer lying atop it, no doubt for use in pounding out shapes in hot metal. Other forge tools hang in racks nearby, and a barrel of water and bellows rest on the floor nearby.",
            "Rusting spikes line the walls and ceiling of this chamber. The dusty floor shows no sign that the walls move over it, but you can see the skeleton of some humanoid impaled on some wall spikes nearby.",
            "Tapestries decorate the walls of this room. Although they may once have been brilliant in hue, they now hang in graying tatters. Despite the damage of time and neglect, you can perceive once-grand images of wizards' towers, magical beasts, and symbols of spellcasting.",
            "This room is walled and floored with black marble veined with white. The ceiling is similarly marbled, but the thick pillars that hold it up are white. A stain of blood drips down one side of a nearby pillar.",
            "This room is shattered. A huge crevasse shears the chamber in half, and the ground and ceilings are tilted away from it. It's as though the room was gripped in two enormous hands and broken like a loaf of bread. Someone has torn a tall stone door from its hinges somewhere else in the dungeon and used it to bridge the 15-foot gap of the chasm between the two sides of the room. Whatever did that must have possessed tremendous strength because the door is huge, and the enormous hinges look bent and mangled.",
            "Neither light nor darkvision can penetrate the gloom in this chamber. An unnatural shade fills it, and the room's farthest reaches are barely visible. Near the room's center, you can just barely perceive a lump about the size of a human lying on the floor.",
            "A flurry of bats suddenly flaps through the doorway, their screeching barely audible as they careen past your heads. They flap past you into the rooms and halls beyond. The room from which they came seems barren at first glance.",
            "A huge stewpot hangs from a thick iron tripod over a crackling fire in the center of this chamber. A hole in the ceiling allows some of the smoke from the fire to escape, but much of it expands across the ceiling and rolls down to fill the room in a dark fog. Other details are difficult to make out, but some creature must be nearby, because something's cooking.",
            "You open the door to the remains of two humans, an elf, and a dwarf lying on the ground in front of you. It seems that they might once have been wearing armor, except for the elf, who remains dressed in a blue robe. Clearly they were defeated and victors stripped them of their valuables.",
            "You feel a sense of foreboding upon peering into this cavernous chamber. At its center lies a low heap of refuse, rubble, and bones atop which sit several huge broken eggshells. Judging by their shattered remains, the eggs were big enough to hold a crouching man, making you wonder how large -- and where -- the mother is.",
            "You open the door to what must be a combat training room. Rough fighting circles are scratched into the surface of the floor. Wooden fighting dummies stand waiting for someone to attack them. A few punching bags hang from the ceiling.",
            "A 30-foot-tall demonic idol dominates this room of black stone. The potbellied statue is made of red stone, and its grinning face holds what looks to be two large rubies in place of eyes. A fire burns merrily in a wide brazier the idol holds in its lap.",
            "A chill crawls up your spine and out over your skin as you look upon this room. The carvings on the wall are magnificent, a symphony in stonework -- but given the themes represented, it might be better described as a requiem. Scenes of death, both violent and peaceful, appear on every wall framed by grinning skeletons and ghoulish forms in ragged cloaks.",
            "A horrendous, overwhelming stench wafts from the room before you. Small cages containing small animals and large insects line the walls. Some of the creatures look sickly and alive but most are clearly dead. Their rotting corpses and the unclean cages no doubt result in the zoo's foul odor. A cat mews weakly from its cage, but the other creatures just silently shrink back into their filthy prisons.",
            "Huge rusted metal blades jut out of cracks in the walls, and rusting spikes project down from the ceiling almost to the floor. This room may have once been trapped heavily, but someone triggered them, apparently without getting killed. The traps were never reset and now seem rusted in place.",
             "This chamber was clearly smaller at one time, but something knocked down the wall that separated it from an adjacent room. Looking into that space, you see signs of another wall knocked over. It doesn't appear that anyone made an effort to clean up the rubble, but some paths through see more usage than others."
        };
            Random rollRoom = new Random();
            int randIndex = rollRoom.Next(rooms.Length);
            string roomDesc = rooms[randIndex];
            return roomDesc;
        }//end GetRoom()
    }//end class
}//namespace
