﻿namespace LeetCode;

public class GroupAnagram
{
		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			List<IList<string>> result = new List<IList<string>>();
			if(strs.Length == 0)
			{
				return result;
			}
			Dictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();
			foreach(var str in strs)
			{
				var key = String.Concat(str.OrderBy(c => c));
				if(!dictionary.ContainsKey(key)) {
					dictionary.Add(key, new List<string> {str});
				}
				else
				{
					if (dictionary.TryGetValue(key, out var value))
					{
						value.Add(str);
						dictionary[key] = value;
					};
				}
			}
			return dictionary.Values.ToList();
		}
		[Theory]
		[InlineData(new object[] { new[] { "eat","tea","tan","ate","nat","bat" } })]
		public void Test(string[] strs)
		{
			var check = GroupAnagrams(strs);
			var a = 1;
		}
}