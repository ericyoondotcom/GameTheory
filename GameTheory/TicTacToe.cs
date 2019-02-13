using System;
using System.Collections.Generic;

namespace GameTheory
{
    public class TicTacToe
    {
       
        /*
         X = AI = Max player
         O = Human = Min player
        */        

        public enum CellState
        {
            X = 1,
            O = -1,
            Blank = 0
        }

        public enum WinState
        {
            X = 1,
            O = -1,
            Tie = 0,
            NoWin = 0
        }

        public TicTacToeNode currentNode;

        public CellState[,] grid {
            get
            {
                return currentNode.grid;
            }
            set
            {
                currentNode = new TicTacToeNode(value, CellState.O).GenerateNodes(); 
            }
        }

        public TicTacToe()
        {
            grid = new CellState[,] { { CellState.Blank, CellState.Blank, CellState.Blank }, { CellState.Blank, CellState.Blank, CellState.Blank }, { CellState.Blank, CellState.Blank, CellState.Blank } };

        }

        public void HumanMove(int row, int col)
        {
            grid[row, col] = CellState.O;
            Console.WriteLine(this);
            Console.WriteLine(CheckWinner(grid));
        }

        public void ComputerMove()
        {
            currentNode = (TicTacToeNode)MinMax.GetValue(new TicTacToeNode(grid, CellState.O).GenerateNodes(), true).best;
            Console.WriteLine(this);
            Console.WriteLine(CheckWinner(grid));
        }

        public static WinState CheckWinner(CellState[,] grid)
        {
            bool tie = true;
            for(int i = 0; i < 3; i++)
            {
                int rowSum = (int)grid[i, 0] + (int)grid[i, 1] + (int)grid[i, 2];
                int colSum = (int)grid[0, i] + (int)grid[1, i] + (int)grid[2, i];
                if(rowSum == 3 || colSum == 3)
                {
                    return WinState.X;
                }
                if(rowSum == -3 || colSum == -3)
                {
                    return WinState.O;
                }
                if (grid[i, 0] == CellState.Blank || grid[i, 1] == CellState.Blank || grid[i, 2] == CellState.Blank) tie = false;
            }
            int dia1 = (int)grid[0, 0] + (int)grid[1, 1] + (int)grid[2, 2];
            int dia2 = (int)grid[2, 0] + (int)grid[1, 1] + (int)grid[0, 2];
            if (dia1 == 3 || dia2 == 3) return WinState.X;
            if (dia1 == -3 || dia2 == -3) return WinState.O;

            if (tie) return WinState.Tie;
            return WinState.NoWin;
        }


        public override string ToString()
        {
            string res = "";
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    switch (grid[i, j])
                    {
                        case CellState.X:
                            res += "X";
                            break;
                        case CellState.O:
                            res += "O";
                            break;
                        case CellState.Blank:
                            res += ".";
                            break;
                    }
                    res += " | ";
                }
                res += "\n------------\n";
            }
            return res;
        }
    }
}
