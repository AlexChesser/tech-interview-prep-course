namespace  _1137_NthTribonacciNumber
{
    public class Solution
    {
        //https://leetcode.com/problems/n-th-tribonacci-number/
        public int Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            int a = 0;
            int b = 1;
            int c = 1;
            int sum = 0;
            while (n > 2)
            {
                sum = a + b + c;
                a = b;
                b = c;
                c = sum;
                n--;
            };
            return sum;
        }
    }
}