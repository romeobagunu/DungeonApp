using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;
using MonsterLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isBattling;
            bool isPlaying;
            bool isRestarting;
            bool isChoosing;

            byte score = 0;

            //Weapons
            Weapon starterSword = new Weapon("Sword", "A blade that looks dull. It ain't much, but it'll get the job done.", 6, 9, 0);
            Weapon starterJavelin = new Weapon("Javelin", "An agile and dependable weapon with a long reach.", 5, 7, 15);
            Weapon starterAxe = new Weapon("Axe", "A heavy tool for a hard worker. If your blow lands, it could do some serious damage.", 8, 10, -10);
            Weapon advSword = new Weapon("Broadsword of a Valiant Hero", "A blade of sharp and durable steel, suitable for a hero.", 8, 12, 5);
            Weapon advJavelin = new Weapon("Pike of a Graceful Warrior", "A  weapon that whistles through the air and pierces with precision.", 9, 11, 20);
            Weapon advAxe = new Weapon("Hammer of a Mighty Fighter", "A bulky and dense weapon that would deal a crushing blow.", 10, 15, -15);

            //Default player
            Player player = new Player("Player", Race.Human, starterSword, 70, 5, 40, 40);

            bool isCustomizing = true;

            do
            {
                isPlaying = true;
                isRestarting = false;

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

                //Monsters

                //Goblins
                Monster gremlin = new Goblin();
                Monster goblin = new Goblin("Goblin Soldier", "A small but viscious creature with a nasty scowl.", 10, 10, 60, 1, 4, 5, true);
                Monster hobgoblin = new Goblin("Hobgoblin", "A fiend of mischief and malice. He grins as he juggles a jagged dagger.", 13, 13, 90, 0, 6, 6, false);
                Monster goblinCommander = new Goblin("Goblin Commander", "Its face is painted with an imprint of blood. Its scars and confident posture indicate you are not the first hero to face him in battle.", 15, 15, 70, 1, 6, 8, true);

                //Orcs
                Monster orc = new Orc();
                Monster orcPillager = new Orc("Orc Pillager", "This brawny orc glares at you with red eyes through his helmet, which hangs on his long horns.", 15, 15, 70, 1, 3, 5, true, false);
                Monster orcGolem = new Orc("Golem", "This lumbering creature has thick skin, which will be difficult to penetrate, even with your newfound weapon.", 18, 18, 30, 3, 4, 6, false, true);
                Monster orcBrute = new Orc("Orc Brute", "This orc wears no armor, and several scars on its chest appear to be self-inflicted, like hash marks counting some achievement. Just how many heroes has he slain with the ball and chain that hangs at his side while he charges towards you?", 20, 20, 70, 1, 7, 10, false, false );

                //Mini-boss: Troll
                Monster miniboss = new Orc("Troll", "A fierce brute of the caves. They're slow but tough and deliver deadly blows.", 20, 20, 35, 2, 8, 12, false, true);

                //Boss: Dragon
                Monster boss = new Monster("Dragon", "A titan of the ancient world. Not many live to this day, but the few that do are terrifying creatures, with tough scales and breath of flames.", 35, 35, 70, 5, 10, 15);

                //Random Encounter
                Random rollMonster = new Random();
                int randomMonster = 0;
                Monster[] monsters = {
                    gremlin, gremlin, gremlin, orc, orc,//Encounters 1-3
                    goblin, goblin, goblin, orcPillager, orcPillager, orcPillager, orcGolem,//Encounters 4-7
                    miniboss,//Encounter 8
                    orcPillager, orcPillager, hobgoblin, hobgoblin, hobgoblin, orcBrute, orcBrute, goblinCommander, goblinCommander, //Encounters 9-12
                    boss //Encounter 13
                    };
                Monster opponent = monsters[0];

                do
                {
                    isBattling = true;

                    //Level Up Logic
                    switch (score)
                    {
                        case 3:
                        case 7:
                        case 12:
                            Console.WriteLine("\n~! Level up! !~\n");
                            isChoosing = true;
                            do
                            {
                                Console.WriteLine("Please select a stat to upgrade:\n" +
                                "1) Health +15hp\n" +
                                "2) Block +2\n" +
                                "3) Accuracy (Hit Chance) +10%\n");

                                ConsoleKey raceChoice = Console.ReadKey(false).Key;
                                Console.Clear();
                                switch (raceChoice)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.H:
                                        isChoosing = false;
                                        player.MaxHP += 15;
                                        break;

                                    case ConsoleKey.D2:
                                    case ConsoleKey.E:
                                        isChoosing = false;
                                        player.Block += 2;
                                        break;

                                    case ConsoleKey.D3:
                                    case ConsoleKey.D:
                                        isChoosing = false;
                                        player.HitChance += 10;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("!! Invalid input, please try again. !!\n");
                                        break;

                                }//end switch - Level up choice
                            } while (isChoosing);//end do while - Level up choice menu

                            player.HP = player.MaxHP;
                            Console.WriteLine("\nYou have also been restored to max health. Good luck, hero.");
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey(false);
                            Console.Clear();

                            break;

                        case 8:
                            Console.WriteLine("\nAs the troll falls to the ground, you take a deep breath and fall to your knee. Looking around, you see the remains of adventurers who had fallen to this mighty foe. The troll had eaten their flesh and discarded their bones - but he collected those 'shiny' weapons in a pile in the corner of his hut.\n" +
                                "You get up and sort thru, finding some old gear, but some weapons that might improve your chances of slaying the dragon...");
                            isChoosing = true;
                            do
                            {
                                Console.WriteLine("Please select a new weapon:\n" +
                                "1) Broadsword of a Valiant Hero\n" +
                                "2) Pike of a Graceful Warrior\n" +
                                "3) Hammer of a Mighty Fighter\n");

                                ConsoleKey raceChoice = Console.ReadKey(false).Key;
                                Console.Clear();
                                switch (raceChoice)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.B:
                                        isChoosing = false;
                                        player.EquippedWeapon = advSword;
                                        break;

                                    case ConsoleKey.D2:
                                    case ConsoleKey.P:
                                        isChoosing = false;
                                        player.EquippedWeapon = advJavelin;
                                        break;

                                    case ConsoleKey.D3:
                                    case ConsoleKey.D:
                                        isChoosing = false;
                                        player.EquippedWeapon = advAxe;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("!! Invalid input, please try again. !!\n");
                                        break;

                                }//end switch - Weapon upgrade choice
                            } while (isChoosing);//end do while - Weapon Upgrade choice menu.

                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey(false);
                            Console.Clear();

                            break;

                        default:
                            break;
                    }

                    //Random Encounter Logic
                    if (score == 12)//Encounter 13 - Boss
                    {
                        Console.WriteLine("You enter into a grand throne room. The tall pillars bear scratches from the claws of a massive creature. The scent of smoke fills the air, and dust and ash cloud your vision. No corpses remain from the conflict, but legends have told you that many died in the massacre: consumed by fire or crush in the jaws of the dragon.\n" +
                            "A low growl echoes through the chamber. Your foe emerges from the shadows, its scales rattling with every step towards you.\n" +
                            "This is your destiny. Good luck, hero.");
                        opponent = monsters[22];
                    }
                    else if (score == 7)//Encounter 8 - Mini-boss
                    {
                        Console.WriteLine("In this chamber, the putrid smell of flesh and blood fill your lungs. Many vile meals have been consumed in this room, which the troll has made its home.\n" +
                            "It emerges from a makeshift hut and spits out the bones of its most recent victim. Its club drags along the ground as it stumbles towards you.\n" +
                            "Good luck, hero.");
                        opponent = monsters[12];
                    }
                    else if (score < 4)//Encounters 1-3
                    {
                        Console.Clear();
                        randomMonster = rollMonster.Next(0, 5);
                        opponent = monsters[randomMonster];
                        Console.WriteLine(GetRoom());
                        Console.WriteLine("\n!! You encounter a " + opponent.Name + " !!");
                    }
                    else if (score < 7)//Encounters 4-7
                    {
                        Console.Clear();
                        randomMonster = rollMonster.Next(6, 12);
                        opponent = monsters[randomMonster];
                        Console.WriteLine(GetRoom());
                        Console.WriteLine("\n!! You encounter a " + opponent.Name + " !!");
                    }
                    else if (score < 12)//Encounters 9-12
                    {
                        Console.Clear();
                        randomMonster = rollMonster.Next(13, 22);
                        opponent = monsters[randomMonster];
                        Console.WriteLine(GetRoom());
                        Console.WriteLine("\n!! You encounter a " + opponent.Name + " !!");
                    }

                    isBattling = true;

                    //Action Menu
                    do
                    {
                        Console.WriteLine("\nChoose an action:\n" +
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
                                    score++;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(opponent.Name + " has been slain.\n" +
                                        "Victory!\n ~ Score: " + score + " ~ \n");
                                    opponent.HP = opponent.MaxHP;
                                    Console.ResetColor();
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey(false);
                                    Console.Clear();
                                    isBattling = false;
                                }
                                if (player.HP <= 0)
                                {
                                    Console.WriteLine("It was a fatal blow...");
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey(false);
                                    Console.Clear();
                                    isBattling = false;
                                }
                                break;
                            case ConsoleKey.R:
                            case ConsoleKey.D2:
                                Console.WriteLine("You attempt to flee...\n");
                                if (score == 7 || score == 12)
                                {
                                    Console.WriteLine("...But you can't run. This battle is your destiny.\n");
                                }
                                else
                                {
                                    Console.WriteLine("But " + opponent.Name + " attacks you as you run!\n");
                                    Battle.DoAttack(opponent, player);
                                    Console.WriteLine();
                                    if (player.HP <= 0)
                                    {
                                        Console.WriteLine("It was a fatal blow...");
                                    }
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey(false);
                                    Console.Clear();
                                    isBattling = false;
                                }
                                break;
                            case ConsoleKey.P:
                            case ConsoleKey.D3:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.WriteLine(" ~ Score: {0} ~ \n", score);
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
                    } while (isBattling);//end if Action Menu

                    //Game Over check
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

                    //Game Completed check
                    if (score == 13)
                    {
                        bool isDeciding = true;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\n ~ Congratulations, you win! ~ \n");
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
                                    isDeciding = false;
                                    break;
                                case ConsoleKey.Q:
                                    Console.Clear();
                                    isRestarting = false;
                                    isPlaying = false;
                                    isDeciding = false;
                                    break;
                                default:
                                    Console.WriteLine("!! Invalid input, please try again. !!");
                                    break;
                            }//end switch
                        } while (isDeciding);
                    }//end Game Complete check

                } while (isPlaying && !isRestarting);//end - Gameplay Loop - Loads up another room.

            } while (isRestarting);//end - Game Loop - Loads up another run.

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
