namespace Leetcode.SlidingWindow;

public class BestTimeToBuyAndSellStock
{
	public int MaxProfit(int[] prices)
	{
		var maxProfit = 0;
		var left = 0;
		var right = 1;

		while (right < prices.Length)
		{
			if (prices[left] < prices[right])
			{
				var profit = prices[right] - prices[left];
				if (maxProfit < profit) maxProfit = profit;
			}
			else
			{
				left = right;
			}

			right++;
		}

		return maxProfit;
	}

	[Theory]
	[InlineData(new[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0, 9 })]
	public void Test(int[] prices)
	{
		var result = MaxProfit(prices);
		Assert.Equal(9, result);
	}
}