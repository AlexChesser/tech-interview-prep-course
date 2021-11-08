namespace  _121_BestTimetoBuyandSellStock
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int min = prices[0];
            int sum = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                else if (prices[i] - min > sum)
                {
                    sum = prices[i] - min;
                }
            }
            return sum;
        }
    }
}