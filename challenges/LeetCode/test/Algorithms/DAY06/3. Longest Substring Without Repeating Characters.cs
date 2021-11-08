using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3_LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            HashSet<char> substring = new HashSet<char>();
            int left = 0, right = 0;
            while (right < s.Length)
            {
                if (!substring.Contains(s[right]))
                {
                    substring.Add(s[right++]);
                    max = Math.Max(max, substring.Count);
                }
                else
                {
                    substring.Remove(s[left++]);
                }
            }
            return max;
        }
    }
}