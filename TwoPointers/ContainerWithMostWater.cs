namespace Leetcode.TwoPointers;

public class ContainerWithMostWater
{
	public int ContainerWithMostWaterSolution(int[] height)
	{
		var maxArea = 0;
		if (height.Length == 2) return height[0] < height[1] ? height[0] : height[1];
		var left = 0;
		var right = height.Length - 1;
		while (left < right)
		{
			var distance = right - left;
			var maxContainer = height[left] < height[right] ? height[left] : height[right];
			var currentArea = distance * maxContainer;
			if (currentArea > maxArea) maxArea = currentArea;
			if (height[left] > height[right]) right--;
			else if (height[left] < height[right]) left++;
			else left++;
		}

		return maxArea;
	}

	[Theory]
	[InlineData(new[] { 4, 3, 2, 1, 4 })]
	public void Test(int[] height)
	{
		var result = ContainerWithMostWaterSolution(height);
		Assert.Equal(16, result);
	}
}