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
            bool isChoosing;
            bool isCustomizing;
            bool isPlaying;
            bool isRestarting;

            byte score = 0;

            //Weapons
            Weapon starterSword = new Weapon("Sword", "A blade that looks dull. It ain't much, but it'll get the job done.", 6, 11, 0);
            Weapon starterJavelin = new Weapon("Javelin", "An agile and dependable weapon with a long reach.", 7, 8, 20);
            Weapon starterAxe = new Weapon("Axe", "A heavy tool for a hard worker. If your blow lands, it could do some serious damage.", 11, 13, -20);

            Weapon advSword = new Weapon("Broadsword of a Valiant Hero", "A blade of sharp and durable steel, suitable for a hero.", 12, 17, 10);
            Weapon advJavelin = new Weapon("Pike of a Graceful Warrior", "A  weapon that whistles through the air and pierces with precision.", 15, 15, 30);
            Weapon advAxe = new Weapon("Hammer of a Mighty Fighter", "A bulky and dense weapon that would deal a crushing blow.", 14, 22, -25);

            //Default player
            Player player = new Player("Player", Race.Human, starterSword, 75, 0, 45, 45);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(@"

                        .     
                      ,*     
                    ,*      
                  ,P       
                ,8*       
              ,dP             
             d8`                
           ,d8`               
          d8P                            
        ,88P                      
       d888*       .d88P            
      d8888b..d888888*          
    ,888888888888888b.           
   ,8*;88888P*****788888888ba.    
  ,8;,8888*        `88888*         
  )8e888*          ,88888be.      
 ,d888`           ,8888888***     
,d88P`           ,8888888Pb.     
888*            ,88888888**   
`88            ,888888888    
 `P           ,8888888888b
______________________________");
            Console.WriteLine("\n ~ ENTER THE DRAGON DUNGEON ~ \n");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(false);
            Console.Clear();

            do
            {
                isPlaying = true;
                isRestarting = false;
                isCustomizing = true;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please enter your name...\n");
                Console.ResetColor();
                player.Name = Console.ReadLine();
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("\n---------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("!! Welcome, " + player.Name + " !!\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("---------------------------------------------------\n");
                Console.ResetColor();

                do
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("_____________________\n" +
                        "Please select a race:\n" +
                        "1) Human\n" +
                        "2) Elf\n" +
                        "3) Dwarf\n");
                    Console.ResetColor();
                    ConsoleKey raceChoice = Console.ReadKey(false).Key;
                    Console.Clear();
                    switch (raceChoice)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.H:
                            isCustomizing = false;
                            player.PlayerRace = Race.Human;
                            player.EquippedWeapon = starterSword;
                            player.Block = 2;
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.E:
                            isCustomizing = false;
                            player.PlayerRace = Race.Elf;
                            player.EquippedWeapon = starterJavelin;
                            player.MaxHP = 75;
                            player.HP = 75;
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.D:
                            player.PlayerRace = Race.Dwarf;
                            player.EquippedWeapon = starterAxe;
                            player.MaxHP = 30;
                            player.HP = 30;
                            player.Block = 5;
                            isCustomizing = false;
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!! Invalid input, please try again. !!\n");
                            Console.ResetColor();
                            break;
                    }
                } while (isCustomizing);//end do while - Race choice

                Console.Clear();

                //Monsters

                //Goblins
                Monster gremlin = new Goblin();
                Monster goblin = new Goblin("GOBLIN SOLDIER", "A small but viscious creature with a nasty scowl.", 10, 10, 80, 0, 10, 13, true);
                Monster hobgoblin = new Goblin("HOBGOBLIN", "A fiend of mischief and malice. He grins as he juggles a jagged dagger.", 13, 13, 90, 1, 16, 16, false);
                Monster goblinCommander = new Goblin("GOBLIN COMMANDER", "Its face is painted with an imprint of blood. Its scars and confident posture indicate you are not the first hero to face him in battle.", 17, 17, 80, 2, 14, 17, true);

                //Orcs
                Monster orc = new Orc();
                Monster orcPillager = new Orc("ORC PILLAGER", "This brawny orc glares at you with red eyes through his helmet, which hangs on his long horns.", 15, 15, 70, 0, 9, 15, true, false);
                Monster orcGolem = new Orc("GOLEM", "This lumbering creature has thick skin, which will be difficult to penetrate.", 18, 18, 40, 1, 12, 17, false, true);
                Monster orcBrute = new Orc("ORC BRUTE", "This orc wears no armor, and several scars on its chest appear to be self-inflicted, like hash marks counting some achievement. Just how many heroes has he slain with the ball and chain that hangs at his side while he charges towards you?", 25, 25, 75, 1, 16, 20, false, false);

                //Mini-boss: Troll
                Monster miniboss = new Orc("TROLL", "A fierce brute of the caves. They're slow but tough and deliver deadly blows. If you're quick, you've got a good shot at evading him. But be cautious - should the battle drag on, your weariness could prove deadly.", 30, 30, 30, 2, 20, 25, false, true);

                //Boss: Dragon
                Monster boss = new Monster("DRAGON", "A titan of the ancient world. Not many live to this day, but the few that do are terrifying creatures, with glittering scales and a sinister gaze. Its talons can shred through the toughest armor, and if you fail to evade its flames, you're toast.", 50, 50, 90, 12, 20, 25);

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
                    System.Threading.Thread.Sleep(100);
                    Console.Clear();
                    //Level Up Logic
                    switch (score)
                    {
                        case 3:
                        case 7:
                        case 12:

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n~! Level up! !~\n");

                            isChoosing = true;

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Please select a stat to upgrade:\n" +
                                "1) Health +20hp\n" +
                                "2) Block +3\n" +
                                "3) Accuracy (Hit Chance) +10%\n");

                                ConsoleKey raceChoice = Console.ReadKey(false).Key;
                                Console.Clear();
                                switch (raceChoice)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.H:
                                        isChoosing = false;
                                        player.MaxHP += 20;
                                        break;

                                    case ConsoleKey.D2:
                                    case ConsoleKey.E:
                                        isChoosing = false;
                                        player.Block += 3;
                                        break;

                                    case ConsoleKey.D3:
                                    case ConsoleKey.D:
                                        if (player.HitChance + player.EquippedWeapon.BonusHitChance > 100)
                                        {
                                            player.HitChance = 100;
                                            Console.Clear();
                                            Console.WriteLine("!! Base hit chance would exceed 100%. Please select another upgrade. !!\n");
                                        }
                                        else
                                        {
                                            player.HitChance += 10;
                                            isChoosing = false;
                                        }
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("!! Invalid input, please try again. !!\n");
                                        Console.ResetColor();
                                        break;

                                }//end switch - Level up choice
                            } while (isChoosing);//end do while - Level up choice menu

                            player.HP = player.MaxHP;
                            Console.WriteLine("\nYou have also been restored to max health. Good luck, hero.");
                            Console.ResetColor();
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
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("!! Invalid input, please try again. !!\n");
                                        Console.ResetColor();
                                        break;

                                }//end switch - Weapon upgrade choice
                            } while (isChoosing);//end do while - Weapon Upgrade choice menu.

                            player.HP = player.MaxHP;
                            Console.WriteLine("\nMay your new weapon serve you well. You have also been restored to max health. Good luck, hero.");
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey(false);
                            Console.Clear();
                            break;

                        default:
                            break;
                    }

                    Console.Clear();
                    //Loading Art
                    Console.Write(@"
Loading...
█
");
                    System.Threading.Thread.Sleep(750);
                    Console.Clear();
                    Console.Write(@"
Loading...
███
");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    Console.Write(@"
Loading...
█████
");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    Console.Write(@"
Loading...
███████
");
                    System.Threading.Thread.Sleep(250);
                    Console.Clear();
                    Console.Write(@"
Done!
██████████
");
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();

                    //Random Encounter Logic
                    if (score == 12)//Encounter 13 - Boss
                    {
                        System.Threading.Thread.Sleep(3000);
                        Console.WriteLine("You enter into a grand throne room. The tall pillars bear scratches from the claws of a massive creature. The scent of smoke fills the air, and dust and ash cloud your vision.\n");
                        System.Threading.Thread.Sleep(8000);
                        Console.WriteLine("No corpses remain from the conflict, but legends have told you that many died in the massacre: consumed by fire or crushed in the jaws of the dragon.\n");
                        System.Threading.Thread.Sleep(8000);
                        Console.WriteLine("A low growl echoes through the chamber. Your foe emerges from the shadows, its scales rattling with every step towards you.\n");
                        System.Threading.Thread.Sleep(8000);
                        Console.WriteLine("This is your destiny.\n");
                        System.Threading.Thread.Sleep(3000);
                        Console.WriteLine("Good luck, hero.");
                        System.Threading.Thread.Sleep(3000);
                        opponent = monsters[22];
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n---------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("!! You encounter " + opponent.Name + " !!\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("---------------------------------------------------\n");
                        Console.ResetColor();
                    }
                    else if (score == 7)//Encounter 8 - Mini-boss
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("In this chamber, the putrid smell of flesh and blood fill your lungs. Many vile meals have been consumed in this room, which the troll has made its home.\n");
                        System.Threading.Thread.Sleep(7000);
                        Console.WriteLine("It emerges from a makeshift hut and spits out the bones of its most recent victim. Its club drags along the ground as it stumbles towards you.\n");
                        System.Threading.Thread.Sleep(5000);
                        Console.WriteLine("Good luck, hero.\n");
                        System.Threading.Thread.Sleep(3000);
                        opponent = monsters[12];
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n---------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("!! You encounter " + opponent.Name + " !!\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("---------------------------------------------------\n");
                        Console.ResetColor();
                    }
                    else if (score <= 2)//Encounters 1-3
                    {
                        Console.Clear();

                        randomMonster = rollMonster.Next(0, 5);

                        System.Threading.Thread.Sleep(30);
                        opponent = monsters[randomMonster];
                        Console.WriteLine(GetRoom());
                        System.Threading.Thread.Sleep(1500);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n---------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("!! You encounter " + opponent.Name + " !!\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("---------------------------------------------------\n");
                        Console.ResetColor();
                    }
                    else if (score <= 6)//Encounters 4-7
                    {
                        Console.Clear();

                        randomMonster = rollMonster.Next(5, 12);

                        System.Threading.Thread.Sleep(30);
                        opponent = monsters[randomMonster];
                        Console.WriteLine(GetRoom());
                        System.Threading.Thread.Sleep(1500);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n---------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("!! You encounter " + opponent.Name + " !!\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("---------------------------------------------------\n");
                        Console.ResetColor();
                    }
                    else if (score <= 11)//Encounters 9-12
                    {
                        Console.Clear();

                        randomMonster = rollMonster.Next(14, 22);

                        System.Threading.Thread.Sleep(30);
                        opponent = monsters[randomMonster];
                        Console.WriteLine(GetRoom());
                        System.Threading.Thread.Sleep(1500);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n---------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("!! You encounter " + opponent.Name + " !!\n");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("---------------------------------------------------\n");
                        Console.ResetColor();
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
                                if (opponent.Name == "DRAGON")
                                {
                                    Random rollDragonAttack = new Random();
                                    int dragonAttack = rollDragonAttack.Next(1, 11);

                                    System.Threading.Thread.Sleep(30);

                                    if (dragonAttack <= 4)
                                    {
                                        Console.WriteLine("\nThe dragon raises its talons to strike at you, exposing its underbelly.\n");
                                        opponent.Block = 3;

                                        Battle.DoBattle(player, opponent);
                                    }//end if - 40% of the time, the dragon attempts to strike with its talons, which gives the player a chance at an effective blow.
                                    else if (dragonAttack <= 7)
                                    {
                                        Console.WriteLine("\nThe dragon rears its head far back, as a flame builds behind its teeth. But you can see its weak spot. Go in for a critical hit!\n");
                                        switch (player.PlayerRace)
                                        {
                                            case Race.Human:
                                                opponent.HitChance = 50;
                                                break;
                                            case Race.Dwarf:
                                                opponent.HitChance = 66;
                                                break;
                                            case Race.Elf:
                                                opponent.HitChance = 33;
                                                break;
                                        }//end switch - Dragon flame breath hit chance varies by player.
                                        opponent.MaxDmg = 35;
                                        opponent.MinDmg = 30;
                                        opponent.Block = 0;

                                        Battle.DoBattle(player, opponent);
                                    }//end else if - 30% of the time, the dragon attempts to hit the player with flame breath.
                                    else
                                    {
                                        Console.WriteLine("\nThe dragon reels back, showing its scales to protect itself from your blow.\n");
                                        Battle.DoAttack(player, opponent);
                                    }//end else - 30% of the time, the dragon will take a defensive turn and rely on its scales for protection.

                                    //Resets dragon stats.
                                    opponent.MaxDmg = 25;
                                    opponent.Block = 12;
                                    opponent.HitChance = 90;
                                    opponent.MinDmg = 20;

                                }//end if - Dragon boss fight
                                else if (opponent.Name == "TROLL")
                                {
                                    switch (player.PlayerRace)
                                    {
                                        case Race.Human:
                                            opponent.HitChance += 10;
                                            break;
                                        case Race.Dwarf:
                                            opponent.HitChance += 15;
                                            break;
                                        case Race.Elf:
                                            opponent.HitChance += 5;
                                            break;
                                    }//end switch - Troll hit chance varies by player race and increases with each combat iteration.

                                    Battle.DoBattle(player, opponent);

                                }//end else if - Troll mini-boss fight
                                else
                                {
                                    Battle.DoBattle(player, opponent);
                                }//end else - normal combat
                                if (opponent.HP <= 0)
                                {
                                    score++;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("\n---------------------------------------------------\n");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("!! " + opponent.Name + " has been slain. !!\n");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("---------------------------------------------------\n");

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n~! Score: " + score + " !~\n");

                                    Console.ResetColor();
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey(false);
                                    Console.Clear();

                                    opponent.HP = opponent.MaxHP;//Resets Monster Object HP in case it is rolled again.

                                    isBattling = false;
                                }//Monster defeated check.
                                if (player.HP <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n!! It was a FATAL blow... !!\n");
                                    Console.ResetColor();
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey(false);
                                    Console.Clear();
                                    isBattling = false;
                                }//Player defeated check.
                                break;
                            case ConsoleKey.R:
                            case ConsoleKey.D2:
                                Console.WriteLine("You attempt to flee...\n");
                                if (score == 7 || score == 12)
                                {
                                    Console.WriteLine("...But you can't run. This battle is your destiny.\n");
                                }//end if - Prevents fleeing from mini-boss and boss.
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
                                }//end else - Monster attempts attack as you run away.
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
                                isRestarting = false;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!! Invalid input, please try again. !!\n");
                                Console.ResetColor();
                                break;
                        }
                    } while (isBattling);//end if Action Menu

                    //Game Over check
                    if (player.HP <= 0)
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(@"
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼
██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼
███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼
██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼
███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼
____________________________________
");
                            Console.Write("Would you like to play again?\n" +
                                "R) Restart\n" +
                                "Q) Quit\n");
                            ConsoleKey gameOverChoice = Console.ReadKey(false).Key;
                            Console.ResetColor();
                            Console.Clear();
                            isChoosing = true;
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
                                    isPlaying = true;
                                    isChoosing = false;
                                    break;
                                case ConsoleKey.Q:
                                    Console.Clear();
                                    isPlaying = false;
                                    isRestarting = false;
                                    isChoosing = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("!! Invalid input, please try again. !!\n");
                                    Console.ResetColor();
                                    break;
                            }//end switch
                        } while (isChoosing);//end do while - Game Over Menu
                    }//end if - Game Over Screen

                    //Game Completed check
                    if (score == 13)
                    {
                        bool isDeciding = true;
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(@"

                        .     
                      ,*     
                    ,*      
                  ,P       
                ,8*       
              ,dP             
             d8`                
           ,d8`               
          d8P                            
        ,88P                      
       d888*       .d88P            
      d8888b..d888888*          
    ,888888888888888b.           
   ,8*;88888P*****788888888ba.    
  ,8;,8888*        `88888*         
  )8e888*          ,88888be.      
 ,d888`           ,8888888***     
,d88P`           ,8888888Pb.     
888*            ,88888888**   
`88            ,888888888    
 `P           ,8888888888b
_____________________________");
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
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("!! Invalid input, please try again. !!\n");
                                    Console.ResetColor();
                                    break;
                            }//end switch
                        } while (isDeciding);
                    }//end Game Complete check

                } while (isPlaying && !isRestarting);//end - Gameplay Loop - Loads up another room.

            } while (isRestarting);//end - Game Loop - Loads up another run.

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"

.▀█▀.█▄█.█▀█.█▄.█.█▄▀　█▄█.█▀█.█─█
─.█.─█▀█.█▀█.█.▀█.█▀▄　─█.─█▄█.█▄█
__________________________________");

            Console.WriteLine("\nThank you for playing!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n__________________________________\n~~~ Final Score: " + score + "~~~\n");
            Console.ResetColor();
            Console.WriteLine();
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
