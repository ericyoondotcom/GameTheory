using System;
namespace GameTheory
{
    public abstract class MinMaxNode
    {
        public int Value { get; set; }
        public virtual MinMaxNode[] Children { get; }


    }
}
