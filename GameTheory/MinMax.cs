using System;
namespace GameTheory
{
    public class MinMax
    {
    
        public (int value, MinMaxNode best) GetValue(MinMaxNode current, bool isMax)
        {
            if (current.children == null || current.children.Length == 0)
            {
                return (current.Value, null);
            }

            MinMaxNode best = null;
            int bestValue = (isMax ? int.MinValue : int.MaxValue);
            Random randy = new Random();
            foreach(MinMaxNode c in current.children)
            {
                int val = GetValue(c, !isMax).value;
                
                if((isMax && ((val > bestValue) || (val == bestValue && randy.Next(2) == 1))) || (!isMax && ((val > bestValue) || (val == bestValue && randy.Next(2) == 1))))
                {
                    best = c;
                    bestValue = val;
                }
            }

            return (bestValue, best);
        }

    }
}
