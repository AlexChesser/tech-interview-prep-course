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
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], nums[i]);
                }
                else
                {
                    map[nums[i]] += nums[i];
                }
            }
            int max = 0;

            List<int> out1 = new List<int>();
            List<int> out2 = new List<int>();
            foreach (var key in map.Keys.OrderBy(k => k))
            {
                out1.Add(key);
                out2.Add(map[key]);
            }
            Trace.WriteLine(out1.ToArray().CommaJoin());
            Trace.WriteLine(out2.ToArray().CommaJoin());
            HashSet<int> skip = new HashSet<int>();
            foreach (int key in map.Keys.OrderBy(k => k))
            {
                if (skip.Contains(key))
                {
                    continue;
                }
                int current = map[key];
                int next = map.ContainsKey(key + 1) ? map[key + 1] : 0;
                int nextPlus = map.ContainsKey(key + 2) ? map[key + 2] : 0;
                if (current + nextPlus > next)
                {
                    Trace.WriteLine($"skipping {key + 1} because {current + nextPlus} > {next}");
                    skip.Add(key + 1);
                    max += current;
                }
                else
                {
                    Trace.WriteLine($"taking {key + 1} because {current + nextPlus} > {next}");
                    skip.Add(key);
                    skip.Add(key + 1);
                    skip.Add(key + 2);
                    max += next;
                }
            }
            return max;
        }
    }
}