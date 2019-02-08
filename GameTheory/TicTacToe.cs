using System;
using System.Collections.Generic;

namespace GameTheory
{
    public class TicTacToe
    {

        public enum CellState
        {
            X,
            O,
            Blank
        }

        public [,] grid;

        public TicTacToe()
        {
            grid = new CellState[,] { { CellState.Blank, CellState.Blank, CellState.Blank }, { CellState.Blank, CellState.Blank, CellState.Blank }, { CellState.Blank, CellState.Blank, CellState.Blank } };

        }

        public void HumanMove(int row, int col)
        {
            grid[row, col] = CellState.O;
        }

        public void ComputerMove()
        {

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
