using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLibrary
{
    public class Screen
    {
        public static void RenderEndScreen(byte score)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"

.▀█▀.█▄█.█▀█.█▄.█.█▄▀　█▄█.█▀█.█─█
─.█.─█▀█.█▀█.█.▀█.█▀▄　─█.─█▄█.█▄█
__________________________________");

            Console.WriteLine("\nThank you for playing!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n__________________________________\n~~~ Final Score: " + score + " ~~~\n");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void RenderGameOver()
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
            Console.ResetColor();
        }
        public static void RenderLoading()
        {
            Console.Clear();
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
        }
        public static void RenderWelcome()
        {
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
_____________________________________");
            Console.WriteLine("\n ~ ENTER THE DRAGON DUNGEON ~ \n");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(false);
            Console.Clear();
        }
    }
}
