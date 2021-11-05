using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _567_Permutation_in_String
{
    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return false;
            }
            char[] key = s1.ToCharArray();
            Array.Sort(key);
            string compareTo = string.Join("", key);
            int left = 0, right = s1.Length;
            while (left + right <= s2.Length)
            {
                char[] tmp = s2.Substring(left++, right).ToCharArray();
                Array.Sort(tmp);
                string compare = string.Join("", tmp);
                if (compare == compareTo)
                {
                    return true;
                }
            }
            return false;
        }
    }
}