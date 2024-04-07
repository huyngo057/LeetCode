namespace Leetcode.TwoPointers;

public class TwoSumII
{
	public int[] TwoSum(int[] numbers, int target)
	{
		var result = new int[2];

		if (numbers.Length == 2) return new[] { 1, 2 };
		var i = 0;
		var j = numbers.Length - 1;
		while (i < j)
		{
			var sum = numbers[i] + numbers[j];
			if (sum == target)
			{
				i++;
				j++;
				return new[] { i, j };
			}

			if (sum > target) j--;
			else if (sum < target) i++;
		}

		return result;
	}

	[Theory]
	[InlineData(new[] { -1, 0 }, -1)]
	public void Test(int[] nums, int k)
	{
		var check = TwoSum(nums, k);
		var a = 1;
	}
}