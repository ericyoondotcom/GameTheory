using System;
namespace GameTheory
{
    public static class MinMax
    {
    
        public static (int value, MinMaxNode best) GetValue(MinMaxNode current, bool isMax, int alpha = int.MinValue, int beta = int.MaxValue)
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

    }
}
