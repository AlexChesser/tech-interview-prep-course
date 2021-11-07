using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace  _740_DeleteandEarn
{
    public class Solution
    {
        public int DeleteAndEarn(int[] nums)
        {
            int[] count = new int[10001];
            foreach (int num in nums)
            {
                count[num]++;
            }
            int skip = 0;
            int take = 0;
            int prev = -1;
            // start at zero but 
            // increment the index before we use it.
            // meaning we effectively start at one
            for (int i = 0; i < count.Length; ++i)
            {
                // if the current index has values
                if (count[i] > 0)
                {
                    // set the current value to the larger
                    // of our previous iteration
                    int m = Math.Max(skip, take);
                    // if our previous number is within a range of 1
                    if (i - 1 != prev)
                    {

                        take = i * count[i] + m;
                        skip = m;
                    }
                    else
                    {
                        take = i * count[i] + skip;
                        skip = m;
                    }
                    prev = i;
                }
            }
            return Math.Max(skip, take);
        }
    }
}