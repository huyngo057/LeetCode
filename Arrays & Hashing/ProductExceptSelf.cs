namespace LeetCode;

public class ProductExceptSelf
{
	public int[]  ProductExceptSelfSolution(int[] nums)
	{ 
		var result = new int[nums.Length];
		var zeroFrequent = 0;
		var totalProduct = 1;
		for (int i = 0; i < nums.Length; i++)
		{
			var currentNum = nums[i];
			if (currentNum == 0)
			{
				zeroFrequent++;
				continue;
			}
			totalProduct *= currentNum;
		}
	
		if (zeroFrequent == 0)
		{
			for (int i = 0; i < nums.Length; i++)
			{
				result[i] = totalProduct / nums[i];
			}

			return result;
		}

		if (zeroFrequent == 1)
		{
			for (int i = 0; i < nums.Length; i++)
			{
				result[i] = nums[i] == 0 ? totalProduct : 0;
			}
			return result;
		}

		for (int i = 0; i < nums.Length; i++)
		{
			result[i] = 0;
		}

		return result;
	}
	
	[Theory]
	[InlineData(new object[] { new[] { 1,2,3,4 } })]
	public void Test(int[] nums)
	{
		var check = ProductExceptSelfSolution(nums);
		var a = 1;
	}
}