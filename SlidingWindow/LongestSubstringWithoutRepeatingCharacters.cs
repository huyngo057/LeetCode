namespace Leetcode.SlidingWindow;

public class LongestSubstringWithoutRepeatingCharacters
{
	public int LengthOfLongestSubstring(string s)
	{
		var left = 0;
		var result = 0;
		var charSet = new HashSet<char>();

		foreach (var c in s)
		{
			while(charSet.Contains(c))
			{
				charSet.Remove(s[left]);
				left++;
			}

			charSet.Add(c);
			result = Math.Max(result, charSet.Count);
		}

		return result;
	}

	[Theory]
	[InlineData("abcabcbb")]
	public void Test(string s)
	{
		var result = LengthOfLongestSubstring(s);
		Assert.Equal(3, result);
	}
}