namespace  _509_FibonacciNumber
{
    public class Solution
    {
        public int Fib_slow(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fib(n - 1) + Fib(n - 2);
        }

        public int Fib(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            int a = 0;
            int b = 1;
            int sum = 0;
            while (n > 1)
            {
                sum = a + b;
                a = b;
                b = sum;
                n--;
            }
            return sum;
        }
    }
}