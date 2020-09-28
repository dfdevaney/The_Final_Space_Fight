using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game_Paired
{
    class Fights
    {
        static readonly Random rando = new Random();

        public static void FirstFight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou get defensive as the enemy approaches you. You draw your sword ready for combat.\n");
            Console.WriteLine("Press any key continue...\n");
            Console.ResetColor();
            Console.ReadKey();
            Combat(true, "", 1, 5);
        }

        public static void FirstBossFight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou hear a loud cackle. As you look up ahead, you notice you are in deep trouble.\n");
            Console.WriteLine("Press any key continue.\n");
            Console.ResetColor();
            Console.ReadKey();
            Combat(false, "Becky The Witch", 4, 4);
        }

        public static void SecondBossFight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou look up ahead, exhausted, and you see a tall alien sharpening his sword staring at you.\n");
            Console.WriteLine("Press any key to continue...\n");
            Console.ResetColor();
            Console.ReadKey();
            Combat(false, "Memphis The Oracle", 4, 4);
        }

        public static void RandomFight()
        {
            switch (rando.Next(0, 3))
            {
                case 0:
                    FirstFight();
                    break;
                case 1:
                    FirstBossFight();
                    break;
                case 2:
                    SecondBossFight();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = ""; //N is for name
            int p = 0; // P is for power
            int h = 0; // H is for health

            if (random)
            {
                n = GetName();
                p = rando.Next(1, 5);
                h = rando.Next(1, 6);
            }

            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0)
            {
                Console.WriteLine(n);
                Console.WriteLine($"Power: {p} \t Health: {h} ");
                Console.WriteLine("======================");
                Console.WriteLine("|  (A)ttack (D)efend  |");
                Console.WriteLine("|  (R)un    (H)eal    |");
                Console.WriteLine("======================");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);
                Console.ForegroundColor = ConsoleColor.Green;
                
                string input = Console.ReadLine();
                Console.ResetColor();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                   
                    Console.WriteLine("\nYou draw your sword and you swing at this creature.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rando.Next(0, Program.currentPlayer.weaponValue) + rando.Next(1, 4);
                    Console.WriteLine("\nYou lose " + damage + " health and deal " + attack + " damage\n");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }

                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    Console.WriteLine("As the " + n + "prepares to strike, you ready your sword to block the incoming attack.");
                    Console.ReadKey();
                }

                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (rando.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You are unable to run. Fight the enemy");
                        Console.ReadKey();
                    }
                }

                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("Uh-oh. You have no more potions remaining.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag and take a big swig of your potion.");
                        Console.WriteLine($"\nYou gain {Program.currentPlayer.potionValue} health.");
                        Program.currentPlayer.health += Program.currentPlayer.potionValue;
                        Program.currentPlayer.potion -= 1;
                        Console.ReadKey();
                    }
                }


                if (Program.currentPlayer.health <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    string EndOfGamePrompt = ($"YOU HAVE DIED. GAME OVER. YOUR TOTAL SCORE IS {Program.currentPlayer.score}.");
                    Console.SetCursorPosition((Console.WindowWidth - EndOfGamePrompt.Length) / 2, Console.CursorTop);
                    Console.WriteLine(EndOfGamePrompt);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            Program.currentPlayer.score++;
            Console.WriteLine($"You have slain the {n}! But it isn't over yet. You see another one.");
        }

        public static string GetName()
        {
            switch (rando.Next(0, 4))
            {
                case 0:
                    return "Alien Grunt";

                case 1:
                    return "Alien Chief";

                case 2:
                    return "Human Hunter";

                case 3:
                    return "Alien Wizard";
            }

            return "A Generic Alien";
        }

    }
}
