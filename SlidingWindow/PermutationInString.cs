namespace Leetcode.SlidingWindow;

public class PermutationInString
{
	public bool CheckInclusion(string s1, string s2)
	{
		var k = s1.Length;
		var left = 0;
		var right = 0;
		var s2Dict = new Dictionary<char, int>();
		var s1Dict = new Dictionary<char, int>();
		if (s1.Length > s2.Length) return false;
		foreach (var c in s1)
			if (!s1Dict.TryGetValue(c, out _))
				s1Dict.Add(c, 1);
			else s1Dict[c]++;

		while (right < s2.Length)
		{
			var rightChar = s2[right];
			s2Dict.TryAdd(rightChar, 0);
			s2Dict[rightChar]++;

			// When the window size matches s1.Length, start checking and then slide the window
			if (right - left + 1 == k)
			{
				// Check if current window is a permutation of s1
				if (AreDictionariesEqual(s1Dict, s2Dict))
				{
					return true;
				}

				var leftChar = s2[left];
				s2Dict[leftChar]--;
				if (s2Dict[leftChar] == 0)
					s2Dict.Remove(leftChar);
				left++;
			}

			right++;
		}

		return false;
	}

	private bool AreDictionariesEqual(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
	{
		if (dict1.Count != dict2.Count) return false;
		foreach (var kvp in dict1)
		{
			if (!dict2.TryGetValue(kvp.Key, out var count) || count != kvp.Value)
				return false;
		}

		return true;
	}

	[Theory]
	[InlineData("ab", "eidboaoo")]
	public void Test(string s1, string s2)
	{
		var result = CheckInclusion(s1, s2);
		Assert.False(result);
	}
}