using System.Collections.Generic;

namespace _387_FirstUniqueCharacterinaString
{
    public class Solution
    {
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!count.ContainsKey(arr[i]))
                {
                    // store position and count
                    count.Add(arr[i], 1);
                }
                else
                {
                    count[arr[i]]++;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (count[arr[i]] == 1) return i;
            }
            return -1;
        }
    }
}