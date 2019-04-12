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

        public ConnectFour(CellState initialState)
        {
            var newGrid = new CellState[6, 7];
            for(int i = 0; i < newGrid.GetLength(0); i++)
            {
                for(int j = 0; j < newGrid.GetLength(1); j++)
                {
                    newGrid[i, j] = CellState.Empty;
                }
            }
            this.currentNode = new ConnectFourNode(newGrid, initialState, 0, 0);
        }

        public WinState WinCheck()
        {
            if (!currentNode.IsTerminal) return WinState.Empty;
            switch (currentNode.Value)
            {
                case 1:
                    return WinState.Mustard;
                case -1:
                    return WinState.Ketchup;
                case 0:
                default:
                    return WinState.Tie;
            }
        }

        public void HumanMove(int column)
        {
            if (WinCheck() != WinState.Empty) return;

            foreach (ConnectFourNode child in currentNode.Children)
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
            if (WinCheck() != WinState.Empty) return;
            currentNode = (ConnectFourNode)GameLogic.MonteCarlo(currentNode, currentNode.player == CellState.Mustard);
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
