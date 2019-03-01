using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTheory
{
    public static class GameLogic
    {
    
        public static (int value, GameNode best) MinMax(GameNode current, bool isMax, int alpha = int.MinValue, int beta = int.MaxValue)
        {
            if (current.IsTerminal)
            {
                return (current.Value, current);
            }

            GameNode best = null;
            int bestValue = (isMax ? int.MinValue : int.MaxValue);
            Random randy = new Random();
            foreach(GameNode c in current.Children)
            {
                int val = MinMax(c, !isMax).value;
                //if ((isMax && (val > bestValue)) || (!isMax && (val < bestValue)))
                if((isMax && ((val > bestValue) || (val == bestValue && randy.Next(2) == 1))) || (!isMax && ((val < bestValue) || (val == bestValue && randy.Next(2) == 1))))
                {
                    if (isMax)
                        alpha = Math.Max(val, alpha);
                    else
                        beta = Math.Min(val, beta);

                    best = c;
                    bestValue = val;
                    if(alpha >= beta)
                    {
                        break;
                    }
                }
            }

            return (bestValue, best);
        }

        public static MonteCarloNode MonteCarlo(MonteCarloNode root, bool isMax, int simulations)
        {
            var visited = new HashSet<MonteCarloNode>();
            for(int i = 0; i < simulations; i++)
            {
                MCSelection(root, isMax, visited);
            }

            int best = -1;
            MonteCarloNode bestNode = null;
            foreach(MonteCarloNode n in root.Children)
            {
                if(n.gamesSimulated > best)
                {
                    best = n.gamesSimulated;
                    bestNode = n;
                }
            }
            return bestNode;
        }

        /// <summary>
        /// Recursive helper function to MonteCarlo()
        /// </summary>
        /// <returns>True if the simulation resulted in a WIN.</returns>
        static bool MCSelection(MonteCarloNode current, bool isMax, HashSet<MonteCarloNode> visited)
        {

            if (!IsFullyEpanded(current, visited))
            {
                //Select random child that isn't visited
                //Set it to visited

                //Todo: Simulate that node.

                //Cut off fake simulated children

                //return loss/win/tie
            }

            //Todo: Select which node to simulate, using the UCT fn.

            //Todo: Unwind recursion and set win/games data. 


        }

        static bool IsFullyEpanded(MonteCarloNode node, HashSet<MonteCarloNode> visited)
        {
            return node.Children.All(n => visited.Contains(node));
        }

    }
}
