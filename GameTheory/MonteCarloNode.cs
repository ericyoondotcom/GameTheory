using System;
namespace GameTheory
{
    public abstract class MonteCarloNode : GameNode
    {
        public float wins { get; set; }
        public float gamesSimulated { get; set; }
        public MonteCarloNode[] Children { get; set; }


        public bool Visited { get; set; }

        public float WinRate
        {
            get
            {
                return wins / gamesSimulated;
            }
        }

        public bool FullyEpanded {
            get
            {
                if (Children.Length == 0) return false;
                for(int i = 0; i < Children.Length; i++)
                {
                    if (Children[i].Visited) return false;
                }
                return true;
            }
        }

        public bool IsTerminal
        {
            get
            {
                return Children == null || Children.Length == 0;
            }
        }
    }
}
