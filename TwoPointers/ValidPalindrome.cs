namespace Leetcode.TwoPointers;

public class ValidPalindrome
{
	public bool IsPalindrome(string s)
	{
		if (s.Length <= 1) return true;

		s = s.ToLower();
		var i = 0;
		var j = s.Length - 1;
		while (i < j)
		{
			var left = s[i];
			var right = s[j];
			if (!((left >= 'a' && left <= 'z') || char.IsDigit(left)))
			{
				i++;
				continue;
			}

			if (!((right >= 'a' && right <= 'z') || char.IsDigit(right)))
			{
				j--;
				continue;
			}

			if (s[i] != s[j]) return false;
			i++;
			j--;
		}

		return true;
	}

	[Theory]
	// [InlineData("A man, a plan, a canal: Panama")]
	// [InlineData("race a car")]
	[InlineData("0P")]
	// [InlineData(" ")]
	public void Test(string s)
	{
		Assert.False(IsPalindrome(s));
	}
}