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
            for(int i = 0; i < simulations; i++)
            {
                __MonteCarlo(root, isMax);
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
        static float __MonteCarlo(MonteCarloNode current, bool isMax)
        {

            if (!current.FullyEpanded)
            {
                MonteCarloNode child = MonteCarloSelect(current);
                return Simulate(child);
            }

            MonteCarloNode best = current.Children[0];
            for(int i = 1; i < current.Children.Length; i++)
            {
                MonteCarloNode n = current.Children[i];
                if (UCT(n, current.gamesSimulated) > UCT(best, current.gamesSimulated))
                {
                    best = n;
                }


            }


            //Todo: Unwind recursion and set win/games data. 


        }

        static MonteCarloNode MonteCarloSelect(MonteCarloNode node)
        {
            Random randy = new Random();
            List<MonteCarloNode> unvisitedChildren = node.Children.Where(n => !n.Visited).ToList();
            MonteCarloNode randomChild = unvisitedChildren[randy.Next(unvisitedChildren.Count)];
            randomChild.Visited = true;
            return randomChild;
        }

        static double UCT(MonteCarloNode child, double parentSims, double rate = 1.4142135624)
        {
            return (child.wins / child.gamesSimulated) + (rate * Math.Sqrt(Math.Log(parentSims) / child.gamesSimulated));
        }

        static float Simulate(MonteCarloNode initial)
        {
            Random randy = new Random();
            MonteCarloNode simulated = initial.Children[randy.Next(initial.Children.Length)];
            while (!simulated.IsTerminal)
            {
                simulated = simulated.Children[randy.Next(simulated.Children.Length)];
            }
            initial.Children = new MonteCarloNode[0];
            return simulated.Value;
        }

    }
}
