using System;

namespace GameTheory
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TicTacToe ttt = new TicTacToe();
            Console.Write(ttt);
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        ttt.HumanMove(0, 0);
                        break;
                    case ConsoleKey.W:
                        ttt.HumanMove(0, 1);
                        break;
                    case ConsoleKey.E:
                        ttt.HumanMove(0, 2);
                        break;
                    case ConsoleKey.A:
                        ttt.HumanMove(1, 0);
                        break;
                    case ConsoleKey.S:
                        ttt.HumanMove(1, 1);
                        break;
                    case ConsoleKey.D:
                        ttt.HumanMove(1, 2);
                        break;
                    case ConsoleKey.Z:
                        ttt.HumanMove(2, 0);
                        break;
                    case ConsoleKey.X:
                        ttt.HumanMove(2, 1);
                        break;
                    case ConsoleKey.C:
                        ttt.HumanMove(2, 2);
                        break;
                }
                ttt.ComputerMove();
            }
        }
    }
}
