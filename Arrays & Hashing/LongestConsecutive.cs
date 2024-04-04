namespace LeetCode;

public class LongestConsecutive
{
	public int LongestConsecutivesolution(int[] nums)
	{
		switch (nums.Length)
		{
			case 0:
				return 0;
			case 1:
				return 1;
		}

		var hashSet = new HashSet<int>(nums);
		var maxLength = 0;
		foreach (var num in nums)
			if (!hashSet.Contains(num - 1))
			{
				var currentNum = num;
				var currentLength = 1;
				while (hashSet.Contains(currentNum + 1))
				{
					currentNum++;
					currentLength++;
				}

				maxLength = Math.Max(maxLength, currentLength);
			}

		return maxLength;
	}

	[Theory]
	[InlineData(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 })]
	public void Test(int[] nums)
	{
		var check = LongestConsecutivesolution(nums);
		var a = 1;
	}
}