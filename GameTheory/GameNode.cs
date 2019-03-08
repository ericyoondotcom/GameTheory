using System;
namespace GameTheory
{
    public abstract class GameNode
    {
        public virtual int Value { get; set; }
        public virtual GameNode[] Children { get; }
        public bool IsTerminal
        {
            get
            {
                return Children == null || Children.Length == 0;
            }
        }


    }
}
