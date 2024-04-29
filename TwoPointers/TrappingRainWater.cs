namespace Leetcode.TwoPointers;

public class TrappingRainWater
{
	public int Trap(int[] height)
	{
		var result = 0;
		var left = 0;
		var right = height.Length - 1;
		var maxLeftHeight = height[left];
		var maxRightHeight = height[right];
		while (left < right)
			if (maxLeftHeight < maxRightHeight)
			{
				left++;
				maxLeftHeight = Math.Max(maxLeftHeight, height[left]);
				result += maxLeftHeight - height[left];
			}
			else
			{
				right--;
				maxRightHeight = Math.Max(maxRightHeight, height[right]);
				result += maxRightHeight - height[right];
			}

		return result;
	}

	[Theory]
	[InlineData(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 })]
	public void Test(int[] height)
	{
		var result = Trap(height);
		Assert.Equal(6, result);
	}
}