namespace Leetcode.TwoPointers;

public class ThreeSum
{
	public IList<IList<int>> ThreeSumSolution(int[] nums)
	{
		var result = new List<IList<int>>();
		if (nums.Length == 3)
		{
			if (nums[0] + nums[1] + nums[2] == 0)
				return new List<IList<int>> { new List<int> { nums[0], nums[1], nums[2] } };
			return result;
		}

		Array.Sort(nums);
		for (var i = 0; i < nums.Length; i++)
		{
			if (i != 0 && nums[i] == nums[i - 1]) continue;
			var left = i + 1;
			var right = nums.Length - 1;

			while (left < right)
			{
				var threeSum = nums[i] + nums[left] + nums[right];
				if (threeSum == 0)
				{
					result.Add(new List<int> { nums[i], nums[left], nums[right] });
					left++;
					while (left < right && nums[left] == nums[left - 1]) left++;
				}

				if (threeSum > 0) right--;
				if (threeSum < 0) left++;
			}
		}

		return result;
	}

	[Theory]
	[InlineData(new[] {-3, -3, 0 , 1, 2, -1, -4, 6 })]
	public void Test(int[] nums)
	{
		var check = ThreeSumSolution(nums);
		var a = 1;
	}
}