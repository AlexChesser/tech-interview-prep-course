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
            s = string.Join("", s.ToCharArray().OrderBy(c => c));
            t = string.Join("", t.ToCharArray().OrderBy(c => c));
            return s == t;
        }
    }
}