using System;
using System.Collections.Generic;

namespace GameTheory
{
    public class TicTacToeNode : MinMaxNode
    {
    

        public TicTacToe.CellState player;
        public TicTacToe.CellState[,] grid;
        List<TicTacToeNode> children;

        public override MinMaxNode[] Children
        {
            get
            {
                if(children == null)
                {
                    GenerateNodes();
                }

                return children.ToArray();
            }
        }

        public TicTacToeNode(TicTacToe.CellState[,] grid, TicTacToe.CellState player)
        {
            this.grid = grid;
            this.player = player;
        }

        

        public TicTacToeNode GenerateNodes()
        {

            if (TicTacToe.CheckWinner(grid) != TicTacToe.WinState.NoWin)
            {
                return this;
            }
            children = new List<TicTacToeNode>();
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] != TicTacToe.CellState.Blank) continue;

                    TicTacToe.CellState[,] newGrid = (TicTacToe.CellState[,])grid.Clone();
                    newGrid[row, col] = (player == TicTacToe.CellState.X ? TicTacToe.CellState.O : TicTacToe.CellState.X);

                    var newChild = new TicTacToeNode(newGrid, (player == TicTacToe.CellState.X ? TicTacToe.CellState.O : TicTacToe.CellState.X));
                    TicTacToe.WinState winner = TicTacToe.CheckWinner(newGrid);
                    if (winner == TicTacToe.WinState.NoWin) newChild.GenerateNodes();
                    newChild.Value = (int)winner;

                    children.Add(newChild);
                }
            }

            return this; //Do this for some cheep chaining
        }

        

        public override string ToString()
        {
            switch (player)
            {
                case TicTacToe.CellState.X:
                    return "X";
                case TicTacToe.CellState.O:
                    return "O";
                case TicTacToe.CellState.Blank:
                    return ".";
                default:
                    return "SOMETHING IS SUPER DUPER WRONG AAAH";
            }
        }

    }
}
