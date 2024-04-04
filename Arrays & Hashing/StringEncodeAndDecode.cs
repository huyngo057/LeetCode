using System.Text;

namespace LeetCode;

public class StringEncodeAndDecode
{
		public string Encode(IList<string> strs)
		{
			var result = new StringBuilder();

			foreach (var str in strs)
			{
				result.Append(str.Length).Append('#').Append(str);
			}

			return result.ToString();
		}

		public List<string> Decode(string s) {
			List<string> decodedStrings = new List<string>();
			var i = 0;
			while (i < s.Length)
			{
				var delimiterIndex = s.IndexOf('#',i);
				var length = int.Parse(s.Substring(i, delimiterIndex - i));
				i = delimiterIndex + 1;
				decodedStrings.Add(s.Substring(i, length));
				i += length;
			}
			return decodedStrings;
		}
		
		[Theory]
		[InlineData(new object[] { new[] {"","   ","!@#$%^&*()_+","LongStringWithNoSpaces","Another, String With, Commas"} })]
		public void Test(string[] strs)
		{
			var check = Encode(strs);
			var check2 = Decode(check);
			var a = 1;
		}
}