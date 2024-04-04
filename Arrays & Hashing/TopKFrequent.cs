namespace LeetCode;

public class TopKFrequent
{
	public int[] TopKFrequentSolution(int[] nums, int k)
	{
		var result = new int[k];
		if (nums.Length == 1) return nums;

		var dictionary = new Dictionary<int, int>();
		foreach (var num in nums)
			if (!dictionary.TryGetValue(num, out var value))
				dictionary.Add(num, 0);
			else
				dictionary[num] = ++value;

		for (var i = 0; i < k; i++)
		{
			var maxValue = dictionary.Values.Max();
			var maxItem = dictionary.First(x => x.Value == maxValue);
			result[i] = maxItem.Key;

			dictionary.Remove(maxItem.Key);
		}

		return result;
	}

	[Theory]
	[InlineData(new[] { 1, 1, 1, 2, 2, 3 }, 2)]
	public void Test(int[] nums, int k)
	{
		var check = TopKFrequentSolution(nums, k);
		var a = 1;
	}
}