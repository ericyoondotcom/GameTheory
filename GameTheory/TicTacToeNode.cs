using System;
using System.Collections.Generic;

namespace GameTheory
{
    public class TicTacToeNode : MinMaxNode
    {

        public TicTacToeNode(TicTacToe.CellState[,] grid, )
        {
            this.grid = grid;
        }

        TicTacToe.CellState[,] grid;

        void GenerateNodes()
        {
            List<MinMaxNode> children = new List<MinMaxNode>();
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] != TicTacToe.CellState.Blank) continue;

                    TicTacToe.CellState[,] newGrid = (TicTacToe.CellState[,])grid.Clone();
                    newGrid[row, col] = 

                    children += new TicTacToeNode()
                }
            }
        }

    }
}
