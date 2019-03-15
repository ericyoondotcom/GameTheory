using System;
using System.Collections.Generic;

namespace GameTheory
{
    public class ConnectFourNode : MonteCarloNode
    {
        public List<ConnectFourNode> children;
        public ConnectFour.CellState[,] grid;
        public ConnectFour.CellState player;
        public int column;
        public override MonteCarloNode[] Children
        {
            get
            {
                if (children == null)
                {
                    children = GenerateChildren();
                }
                return children.ToArray();
            }

        }

        public ConnectFourNode(ConnectFour.CellState[,] grid, ConnectFour.CellState player, int column)
        {
            this.grid = grid;
            this.player = player;
            this.column = column;
        }

        public override int Value {
            get
            {
                for(int i = 0; i < grid.GetLength(0); i++)
                {
                    for(int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (
                            i < grid.GetLength(0) - 4 &&
                            grid[i, j] == ConnectFour.CellState.Mustard &&
                            grid[i + 1, j] == ConnectFour.CellState.Mustard &&
                            grid[i + 2, j] == ConnectFour.CellState.Mustard &&
                            grid[i + 3, j] == ConnectFour.CellState.Mustard
                        )
                        {
                            return 1;
                        }

                        if (
                            i < grid.GetLength(0) - 4 &&
                            grid[i, j] == ConnectFour.CellState.Ketchup &&
                            grid[i + 1, j] == ConnectFour.CellState.Ketchup &&
                            grid[i + 2, j] == ConnectFour.CellState.Ketchup &&
                            grid[i + 3, j] == ConnectFour.CellState.Ketchup
                        )
                        {
                            return -1;
                        }

                        if (
                            j < grid.GetLength(1) - 4 &&
                            grid[i, j] == ConnectFour.CellState.Mustard &&
                            grid[i, j + 1] == ConnectFour.CellState.Mustard &&
                            grid[i, j + 2] == ConnectFour.CellState.Mustard &&
                            grid[i, j + 3] == ConnectFour.CellState.Mustard
                        )
                        {
                            return 1;
                        }

                        if (
                            j < grid.GetLength(1) - 4 &&
                            grid[i, j] == ConnectFour.CellState.Ketchup &&
                            grid[i, j + 1] == ConnectFour.CellState.Ketchup &&
                            grid[i, j + 2] == ConnectFour.CellState.Ketchup &&
                            grid[i, j + 3] == ConnectFour.CellState.Ketchup
                        )
                        {
                            return -1;
                        }

                        // TODO: Diagonal checks

                    }
                }
                return 0;

            }
        }

        public List<ConnectFourNode> GenerateChildren()
        {
            List<ConnectFourNode> newChildren = new List<ConnectFourNode>();
            for(int i = 0; i < grid.GetLength(1); i++)
            {
                ConnectFour.CellState[,] newGrid = (ConnectFour.CellState[,])grid.Clone();
                for(int j = 0; j < grid.GetLength(0); j++)
                {
                    if(grid[j, i] == ConnectFour.CellState.Empty)
                    {
                        ConnectFour.CellState newPlayer = (player == ConnectFour.CellState.Ketchup ? ConnectFour.CellState.Mustard : ConnectFour.CellState.Ketchup);
                        newGrid[j, i] = newPlayer;
                        newChildren.Add(new ConnectFourNode(newGrid, newPlayer, i));
                        break;
                    }
                }
            }
            return newChildren;
        }

        public override string ToString()
        {
            switch (player)
            {
                case ConnectFour.CellState.Ketchup:
                    return "X";
                case ConnectFour.CellState.Mustard:
                    return "O";
                case ConnectFour.CellState.Empty:
                    return " ";
                default:
                    return "THIS SHOULD NOT HAPPEN PANIC PANIC PANIC";
            }
        }
    }
}
