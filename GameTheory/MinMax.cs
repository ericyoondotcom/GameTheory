using System;
namespace GameTheory
{
    public static class MinMax
    {
    
        public static (int value, MinMaxNode best) GetValue(MinMaxNode current, bool isMax)
        {
            if (current.Children == null || current.Children.Length == 0)
            {
                return (current.Value, current);
            }

            MinMaxNode best = null;
            int bestValue = (isMax ? int.MinValue : int.MaxValue);
            Random randy = new Random();
            foreach(MinMaxNode c in current.Children)
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
