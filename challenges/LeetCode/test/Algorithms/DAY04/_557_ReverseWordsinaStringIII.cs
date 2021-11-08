using System;
using System.Diagnostics;

namespace _557_ReverseWordsinaStringIII
{
    public class Solution
    {
        public void ReverseString(char[] s, int from, int to)
        {
            int left = from, right = to - 1;
            while (left <= right)
            {
                char tmp = s[left];
                s[left++] = s[right];
                s[right--] = tmp;
            }
        }

        public string ReverseWords(string s)
        {
            char[] chars = s.ToCharArray();
            int previous = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ' ')
                {
                    ReverseString(chars, previous, i);
                    previous = i + 1;
                }
            }
            ReverseString(chars, previous, chars.Length);
            return string.Join("", chars);
        }
    }
}