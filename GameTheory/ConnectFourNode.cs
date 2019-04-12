using System;
using System.Collections.Generic;

namespace GameTheory
{
    public class ConnectFourNode : MonteCarloNode
    {
        List<ConnectFourNode> children;
        public ConnectFour.CellState[,] grid;
        public ConnectFour.CellState player;
        public int column;
        public int moveNumber = 0;
        public override MonteCarloNode[] Children
        {
            get
            {
                if (children == null)
                {
                    children = GenerateChildren(moveNumber + 1);
                }
                return children.ToArray();
            }

        }

        public ConnectFourNode(ConnectFour.CellState[,] grid, ConnectFour.CellState player, int column, int moveNumber)
        {
            this.grid = grid;
            this.player = player;
            this.column = column;
            this.moveNumber = moveNumber;
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

                        if (
                            j < grid.GetLength(1) - 3 && i < grid.GetLength(0) - 3 &&
                            grid[i, j] == ConnectFour.CellState.Mustard &&
                            grid[i + 1, j + 1] == ConnectFour.CellState.Mustard &&
                            grid[i + 2, j + 2] == ConnectFour.CellState.Mustard &&
                            grid[i + 3, j + 3] == ConnectFour.CellState.Mustard
                        )
                        {
                            return 1;
                        }
                        if (
                            j < grid.GetLength(1) - 3 && i < grid.GetLength(0) - 3 &&
                            grid[i, j] == ConnectFour.CellState.Ketchup &&
                            grid[i + 1, j + 1] == ConnectFour.CellState.Ketchup &&
                            grid[i + 2, j + 2] == ConnectFour.CellState.Ketchup &&
                            grid[i + 3, j + 3] == ConnectFour.CellState.Ketchup
                        )
                        {
                            return -1;
                        }
                        if (
                            j < grid.GetLength(1) - 3 && i < grid.GetLength(0) - 3 &&
                            grid[i, j + 3] == ConnectFour.CellState.Mustard &&
                            grid[i + 1, j + 2] == ConnectFour.CellState.Mustard &&
                            grid[i + 2, j + 1] == ConnectFour.CellState.Mustard &&
                            grid[i + 3, j] == ConnectFour.CellState.Mustard
                        )
                        {
                            return 1;
                        }
                        if (
                            j < grid.GetLength(1) - 3 && i < grid.GetLength(0) - 3 &&
                            grid[i, j + 3] == ConnectFour.CellState.Ketchup &&
                            grid[i + 1, j + 2] == ConnectFour.CellState.Ketchup &&
                            grid[i + 2, j + 1] == ConnectFour.CellState.Ketchup &&
                            grid[i + 3, j] == ConnectFour.CellState.Ketchup
                        )
                        {
                            return -1;
                        }

                    }
                }
                return 0;

            }
        }

        public bool IsTie
        {
            get
            {
                foreach(ConnectFour.CellState cell in grid)
                {
                    if (cell == ConnectFour.CellState.Empty) return false;
                }
                return true;
            }
        }

        public List<ConnectFourNode> GenerateChildren(int moveNumber)
        {
            List<ConnectFourNode> newChildren = new List<ConnectFourNode>();

            if(moveNumber == 2)
            {
                ConnectFour.CellState[,] newGrid = (ConnectFour.CellState[,])grid.Clone();
                ConnectFour.CellState newPlayer = (player == ConnectFour.CellState.Ketchup ? ConnectFour.CellState.Mustard : ConnectFour.CellState.Ketchup);
                int i;
                for(i = 0; i < grid.GetLength(1); i++)
                {
                    bool breakFlag = false;
                    for(int j = 0; j < grid.GetLength(0); j++)
                    {
                        if(grid[j, i] == ConnectFour.CellState.Ketchup)
                        {
                            newGrid[j, i] = ConnectFour.CellState.Mustard;
                            breakFlag = true;
                        }
                        if (grid[j, i] == ConnectFour.CellState.Mustard)
                        {
                            newGrid[j, i] = ConnectFour.CellState.Ketchup;
                            breakFlag = true;
                        }
                        break;
                    }
                    if (breakFlag) break;
                }

                ConnectFourNode newNode = new ConnectFourNode(newGrid, newPlayer, -1, moveNumber);
                newNode.IsTerminal = newNode.Value != 0 || newNode.IsTie;
                newNode.moveNumber = moveNumber;
                newChildren.Add(newNode);
            }

            for (int i = 0; i < grid.GetLength(1); i++)
            {
                ConnectFour.CellState[,] newGrid = (ConnectFour.CellState[,])grid.Clone();
                for(int j = 0; j < grid.GetLength(0); j++)
                {
                    if(grid[j, i] == ConnectFour.CellState.Empty)
                    {
                        ConnectFour.CellState newPlayer = (player == ConnectFour.CellState.Ketchup ? ConnectFour.CellState.Mustard : ConnectFour.CellState.Ketchup);
                        newGrid[j, i] = newPlayer;
                        ConnectFourNode newNode = new ConnectFourNode(newGrid, newPlayer, i, moveNumber);
                        newNode.IsTerminal = newNode.Value != 0 || newNode.IsTie;
                        newChildren.Add(newNode);
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
