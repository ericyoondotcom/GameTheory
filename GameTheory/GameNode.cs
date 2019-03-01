using System;
namespace GameTheory
{
    public abstract class GameNode
    {
        public int Value { get; set; }
        public GameNode[] Children { get; }
        public bool IsTerminal
        {
            get
            {
                return Children == null || Children.Length == 0;
            }
        }


    }
}
