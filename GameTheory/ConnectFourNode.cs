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
                throw new NotImplementedException();
                //TODO: Implement a win check
            }
        }

        List<ConnectFourNode> GenerateChildren()
        {
            List<ConnectFourNode> newChildren = new List<ConnectFourNode>();
            for(int i = 0; i < grid.GetLength(1); i++)
            {
                var newGrid = grid;
                for(int j = grid.GetLength(0) - 1; j >= 0; j--)
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
