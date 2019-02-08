using System;
namespace GameTheory
{
    public interface MinMaxNode
    {
        int Value { get; }

        MinMaxNode[] children { get; set; }
    }
}
