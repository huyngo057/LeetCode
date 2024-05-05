namespace Leetcode.SlidingWindow;

public class LongestRepeatingCharacterReplacement
{
	public int CharacterReplacement(string s, int k)
	{
		var left = 0;
		var right = 0;
		var result = 0;
		var maxFrequency = 0;
		var freqDict = new Dictionary<char, int>();

		while (right < s.Length)
		{
			if (!freqDict.TryGetValue(s[right], out var value)) freqDict.Add(s[right], 1);
			else
				freqDict[s[right]]++;

			maxFrequency = Math.Max(maxFrequency, freqDict[s[right]]);
			if (right - left + 1 - maxFrequency > k)
			{
				freqDict[s[left]]--;
				left++;
			}

			result = Math.Max(result, right - left + 1);
			right++;
		}

		return result;
	}

	[Theory]
	[InlineData("AABABBA", 1)]
	public void Test(string s, int k)
	{
		var result = CharacterReplacement(s, k);
		Assert.Equal(4, result);
	}
}