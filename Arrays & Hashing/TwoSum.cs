global using Xunit;
using System.Collections;

namespace LeetCode;

public class TwoSum
{
    public int[] Solution(int[] nums, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int temp = target - nums[i];

            if (dictionary.TryGetValue(temp, out _))
            {
                return new[] { dictionary[temp], i };
            }

            dictionary[nums[i]] = i;
        }

        return new int[] { };
    }

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    public void Test(int[] nums, int expected, int[] index)
    {
        Assert.Equal(index, Solution(nums, expected));
    }
}