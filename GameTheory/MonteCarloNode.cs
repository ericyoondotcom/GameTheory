using System;
namespace GameTheory
{
    public abstract class MonteCarloNode : GameNode
    {
        public int wins { get; set; }
        public int gamesSimulated { get; set; }
        public MonteCarloNode[] Children { get; set; }

        public bool IsTerminal
        {
            get
            {
                return Children == null || Children.Length == 0;
            }
        }
    }
}
