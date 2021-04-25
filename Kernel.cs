using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace FurryOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("FurryOS booted successfully, type help for commands.");
        }

        protected override void Run()
        {
            Console.Write(">");
            var input = Console.ReadLine();
            input = input.ToLower();
            if (input == "info")
            {
                Console.WriteLine("running FurryOS 0.0.3");
            }
            else if (input == "help")
            {
                Console.WriteLine("commands:");
                Console.WriteLine("info: shows info about the OS");
                Console.WriteLine("shutdown: shuts down the system");
                Console.WriteLine("hewwo: OwO");
                Console.WriteLine("coinflip: play a coinflip game");
                Console.WriteLine("help: opens this menu");

            }
            else if(input == "hewwo")
            {
                Console.WriteLine("hewwo OwO");
            }else if(input == "shutdown")
            {
                Cosmos.System.Power.Shutdown();
            }else if(input == "coin flip" || input == "coinflip")
            {
                string[] choices = { "Heads", "Tails" };
                Console.WriteLine("Choose: Heads or Tails");
                Random r = new Random();
                bool rollStatus = false;
                int i = r.Next(0, 2);
                int attempts = 1;
                do
                {
                    if (Console.ReadLine() != choices[i])
                    {
                        Console.WriteLine($"OOF! The coin landed on {choices[1]}. Better Luck next time.");
                        attempts++;
                        i = r.Next(0, 2);
                        Console.WriteLine("\nChoose: Heads or Tails");
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You have chosen the same result as the coin toss in {attempts} attempts!");
                        rollStatus = true;
                    }
                    Console.WriteLine(" ");
                } while (rollStatus == false);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }else if(input == "cls" || input == "clear")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("invalid command " + input + " detected type help for a list of commands");
            }

        }
    }
}
