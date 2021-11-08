using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _567_Permutation_in_String
{
    public class Solution
    {
        public bool CheckInclusion_slow(string s1, string s2)
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

        public bool CheckInclusion(string s1, string s2)
        {

            if (s1.Length > s2.Length)
            {
                return false;
            }
            if (s1.Length == 0)
            {
                return true;
            }
            int[] s1map = new int[26];
            int[] s2map = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                s1map[s1[i] - 'a']++;
                s2map[s2[i] - 'a']++;
            }
            // Console.WriteLine($"{string.Join("", s1map)}\n{string.Join("", s2map)}\n\n");
            int left = 0, right = s1.Length;
            while (right < s2.Length)
            {
                if (s1map.SequenceEqual(s2map))
                {
                    return true;
                }
                // Console.WriteLine($"dec {s2[left]} inc {s2[right]}");
                s2map[s2[left++] - 'a']--;
                s2map[s2[right++] - 'a']++;
                // Console.WriteLine($"{string.Join("", s1map)}\n{string.Join("", s2map)}\n\n");
            }
            // Console.WriteLine($"{string.Join("", s1map)}\n{string.Join("", s2map)}\n\n");
            return s1map.SequenceEqual(s2map);
        }
    }
}