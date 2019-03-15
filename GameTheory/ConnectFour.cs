using System;
namespace GameTheory
{

    /*
       
     * Ketchup = X = -1
     * Mustard = O = 1
        
    */


    public class ConnectFour
    {

        public enum CellState
        {
            Mustard,
            Ketchup,
            Empty
        }
        public enum WinState
        {
            Mustard,
            Ketchup,
            Tie,
            Empty
        }

        public ConnectFourNode currentNode;
        public CellState[,] Grid
        {
            get
            {
                return currentNode.grid;
            }
        }

        public ConnectFour()
        {
            var newGrid = new CellState[7, 6];
            for(int i = 0; i < newGrid.GetLength(0); i++)
            {
                for(int j = 0; j < newGrid.GetLength(1); j++)
                {
                    newGrid[i, j] = CellState.Empty;
                }
            }
            this.currentNode = new ConnectFourNode(newGrid, CellState.Mustard, 0);
        }

        public void HumanMove(int column)
        {
            foreach(ConnectFourNode child in currentNode.Children)
            {
                if(child.column == column)
                {
                    currentNode = child;
                    return;
                }
            }
            Console.WriteLine("That's not a valid option, you cheater");
        }
        public void ComputerMove()
        {
            currentNode = (ConnectFourNode)GameLogic.MonteCarlo(currentNode, true, 100);
        }

        public override string ToString()
        {
            string res = "\n";

            for (int i = 0; i < Grid.GetLength(1); i++)
                res += "  " + (i + 1).ToString() + " ";
            res += "\n";
            for (int i = Grid.GetLength(0) - 1; i >= 0; i--)
            {
                res += "| ";
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    switch (Grid[i, j])
                    {
                        case CellState.Ketchup:
                            res += "X";
                            break;
                        case CellState.Mustard:
                            res += "O";
                            break;
                        case CellState.Empty:
                            res += " ";
                            break;
                    }
                    res += " | ";
                }

                res += "\n";
            }
            return res;
        }

    }
}
