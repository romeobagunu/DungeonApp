using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;
using MonsterLibrary;
using VisualLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Menu and Score Variables
            //Menu Bools
            bool isCustomizing;
            bool isBattling;
            bool isChoosing;
            bool isPlaying;
            bool isRestarting;

            //Score Counter
            byte score = 0;
            //Change initial value of score to test different stages in the game.
            #endregion

            #region Instantiations
            //Weapons
            Weapon starterSword = new Weapon("Sword", "A blade that looks dull. It ain't much, but it'll get the job done.", 6, 11, 0);
            Weapon starterJavelin = new Weapon("Javelin", "An agile and dependable weapon with a long reach.", 7, 8, 20);
            Weapon starterAxe = new Weapon("Axe", "A heavy tool for a hard worker. If your blow lands, it could do some serious damage.", 11, 13, -20);

            Weapon advSword = new Weapon("Broadsword of a Valiant Hero", "A blade of sharp and durable steel, suitable for a hero.", 12, 17, 10);
            Weapon advJavelin = new Weapon("Pike of a Graceful Warrior", "A  weapon that whistles through the air and pierces with precision.", 15, 15, 30);
            Weapon advAxe = new Weapon("Hammer of a Mighty Fighter", "A bulky and dense weapon that would deal a crushing blow.", 14, 22, -25);

            //Player
            Player player = new Player("Player", Race.Human, starterSword, 75, 0, 45, 45);


            #endregion

            Screen.RenderWelcome();

            #region Game Loop
            do
            {
                isPlaying = true;
                isRestarting = false;

                #region Player Customization
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
                #endregion

                #region Monster Instantiations
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
                Troll miniboss = new Troll();

                //Boss: Dragon
                Dragon boss = new Dragon();
                #endregion

                #region Random Object and Monster Array
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
                #endregion

                #region Gameplay
                do
                {
                    isBattling = true;
                    System.Threading.Thread.Sleep(100);
                    Console.Clear();

                    //Level Up Logic + Troll Loot Drop
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
                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        break;

                                }//end switch - Weapon upgrade choice
                            } while (isChoosing);//end do while - Weapon Upgrade choice menu.

                            player.HP = player.MaxHP;
                            Console.WriteLine("\nMay your new weapon serve you well. You have also been restored to max health. Good luck, hero.");
                            Console.ResetColor();
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey(false);
                            Console.Clear();
                            break;

                        default:
                            break;
                    }

                    //Loading Art Animation
                    Screen.RenderLoading();

                    //Random Encounter Logic
                    #region Random Encounters
                    if (score == 12)//Encounter 13 - Boss
                    {
                        opponent = monsters[22];

                        Room.GetDragonRoom();

                        Room.RenderEncounter(opponent.Name);
                    }
                    else if (score == 7)//Encounter 8 - Mini-boss
                    {
                        Console.Clear();

                        opponent = monsters[12];

                        Room.GetTrollRoom();

                        Room.RenderEncounter(opponent.Name);
                    }
                    else if (score <= 2)//Encounters 1-3
                    {
                        Console.Clear();

                        randomMonster = rollMonster.Next(0, 5);

                        opponent = monsters[randomMonster];

                        Console.WriteLine(Room.GetRoom());

                        Room.RenderEncounter(opponent.Name);
                        
                    }
                    else if (score <= 6)//Encounters 4-7
                    {
                        Console.Clear();

                        randomMonster = rollMonster.Next(5, 12);
                        opponent = monsters[randomMonster];
                        
                        Console.WriteLine(Room.GetRoom());
                        
                        Room.RenderEncounter(opponent.Name);
                    }
                    else if (score <= 11)//Encounters 9-12
                    {
                        Console.Clear();

                        randomMonster = rollMonster.Next(14, 22);

                        opponent = monsters[randomMonster];
                        
                        Console.WriteLine(Room.GetRoom());
                        
                        Room.RenderEncounter(opponent.Name);
                    }
                    #endregion  

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
                                if (opponent.GetType().Equals(typeof(Dragon)))
                                {
                                    Dragon dragon = (Dragon)opponent;
                                    dragon.RollForAttack(player.PlayerRace);
                                    Battle.DoBattle(player, dragon);
                                }//end if - Dragon boss fight
                                else if (opponent.GetType().Equals(typeof(Troll)))
                                {
                                    Troll troll = (Troll)opponent;
                                    troll.TirePlayer(player.PlayerRace);
                                    Battle.DoBattle(player, troll);
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
                    } while (isBattling);

                    //Game Over Check
                    if (player.HP <= 0)
                    {
                        do
                        {
                            Screen.RenderGameOver();
                            Console.Write("Would you like to play again?\n" +
                                "R) Restart\n" +
                                "Q) Quit\n");
                            ConsoleKey gameOverChoice = Console.ReadKey(false).Key;
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
                    }

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
                #endregion

            } while (isRestarting);//end - Game Loop - Loads up another run.
            #endregion

            //Thank you for playing!
            Screen.RenderEndScreen(score);

        }//end Main()

    }//end class
}//namespace
