using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game_Paired
{
    class Program
    {
        public static Player currentPlayer = new Player(); //This creates a new instance of the player.
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Fights.FirstFight();
            while (mainLoop)
            {
                Fights.RandomFight();
            }
            
        }

        static void Start()
        {
            string TitleOfGame = "The Final Space Fight";
            Console.SetCursorPosition((Console.WindowWidth - TitleOfGame.Length) / 2, Console.CursorTop);
            Console.WriteLine(TitleOfGame);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWhat is your name?\n");
            currentPlayer.name = Console.ReadLine();
            Console.WriteLine("\nPress any to continue...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\nYou wake up to find yourself on a strange purple planet. " +
                "You look around and you see aliens fly in Maseratti's. You are bewildered" +
                " by what you see.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            
            Console.WriteLine("\nA youngling comes to approach you. But, he has no good intentions. " +
                "Luckily, none of your weapons were stripped when you were unconscious. You get ready for a fight.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
