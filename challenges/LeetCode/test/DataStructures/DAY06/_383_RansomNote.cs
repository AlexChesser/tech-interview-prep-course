using System.Collections.Generic;

namespace _383_RansomNote
{
    public class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (magazine.Length < ransomNote.Length)
            {
                return false;
            }
            Dictionary<char, int> lettersCount = new();
            char[] mag = magazine.ToCharArray();
            foreach (char c in mag)
            {
                if (!lettersCount.ContainsKey(c))
                {
                    lettersCount.Add(c, 1);
                }
                else
                {
                    lettersCount[c]++;
                }
            }
            foreach (char c in ransomNote)
            {
                if (!lettersCount.ContainsKey(c))
                {
                    return false;
                }
                if (--lettersCount[c] == 0)
                {
                    lettersCount.Remove(c);
                }
            }
            return true;
        }
    }
}