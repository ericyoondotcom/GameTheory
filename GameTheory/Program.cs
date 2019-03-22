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
                    Console.WriteLine("\n\nYour turn! Press keys 1-7 to move, press M for the computer to move for you. Enter to start new game");
                    bool exit = false;
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            game.HumanMove(0);
                            break;
                        case ConsoleKey.D2:
                            game.HumanMove(1);
                            break;
                        case ConsoleKey.D3:
                            game.HumanMove(2);
                            break;
                        case ConsoleKey.D4:
                            game.HumanMove(3);
                            break;
                        case ConsoleKey.D5:
                            game.HumanMove(4);
                            break;
                        case ConsoleKey.D6:
                            game.HumanMove(5);
                            break;
                        case ConsoleKey.D7:
                            game.HumanMove(6);
                            break;
                        case ConsoleKey.M:
                            game.ComputerMove();
                            break;
                        case ConsoleKey.Enter:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Oopsies, that isn't an option. Moving random for you :)");
                            Random randy = new Random();
                            game.HumanMove(randy.Next(7));
                            break;
                    }

                    if (exit) break;
                    game.ComputerMove();

                    Console.Write(game);
                    if(game.WinCheck() != ConnectFour.WinState.Empty)
                    {
                        Console.WriteLine(game.WinCheck());
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}
