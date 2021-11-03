using System;
using System.Diagnostics;

namespace _344_ReverseString
{
    public class Solution
    {
        public void ReverseString(char[] s)
        {
            int left = 0, right = s.Length - 1;
            while (left <= right)
            {
                char tmp = s[left];
                s[left++] = s[right];
                s[right--] = tmp;
            }
        }
    }
}