using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLibrary
{
    public class Room
    {
        public static string GetRoom()
        {
            System.Threading.Thread.Sleep(30);
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
        }

        public static void GetTrollRoom()
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("In this chamber, the putrid smell of flesh and blood fill your lungs. Many vile meals have been consumed in this room, which the troll has made its home.\n");
            System.Threading.Thread.Sleep(7000);
            Console.WriteLine("It emerges from a makeshift hut and spits out the bones of its most recent victim. Its club drags along the ground as it stumbles towards you.\n");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Good luck, hero.\n");
            System.Threading.Thread.Sleep(3000);
        }

        public static void GetDragonRoom()
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
        }

        public static void RenderEncounter(string opponentName)
        {
            System.Threading.Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n---------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("!! You encounter " + opponentName + " !!\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("---------------------------------------------------\n");
            Console.ResetColor();
        }
    }
}
