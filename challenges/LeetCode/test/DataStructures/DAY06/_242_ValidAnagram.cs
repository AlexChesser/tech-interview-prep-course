using System.Collections.Generic;
using System.Linq;

namespace _242_ValidAnagram
{
    public class Solution
    {
        /*
        Example 1:

    Input: s = "anagram", t = "nagaram"
    Output: true

    Example 2:

    Input: s = "rat", t = "car"
    Output: false

        */
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> chars = new Dictionary<char, int>();
            foreach (char c in s.ToCharArray())
            {
                if (!chars.ContainsKey(c))
                {
                    chars.Add(c, 1);
                }
                else
                {
                    chars[c]++;
                }
            }
            foreach (char c in t.ToCharArray())
            {
                if (!chars.ContainsKey(c))
                {
                    return false;
                }
                if (--chars[c] <= 0)
                {
                    chars.Remove(c);
                }
            }
            return true;
        }
    }
}