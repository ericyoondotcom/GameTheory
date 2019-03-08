using System;

namespace GameTheory
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                ConnectFour game = new ConnectFour();
                Console.Clear();
                Console.WriteLine("Do you want to go first? (Y/n)");
                if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    game.ComputerMove();
                }
                Console.Write(game);
                while (true)
                {
                    bool exit = false;
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            game.HumanMove(0);
                            break;
                        case ConsoleKey.Enter:
                            exit = true;
                            break;
                    }
                    if (exit) break;
                    game.ComputerMove();

                }
            }
        }
    }
}
