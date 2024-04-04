namespace LeetCode;

public class IsValidSudoku
{
	public bool IsValidSudokuSolution(char[][] board)
	{
		for (var i = 0; i < 9; i++)
		{
			var dictionary = new Dictionary<char, char>();
			for (var j = 0; j < 9; j++)
			{
				if (board[i][j] == '.') continue;
				if (dictionary.ContainsKey(board[i][j])) return false;

				dictionary.Add(board[i][j], board[i][j]);
			}
		}

		for (var i = 0; i < 9; i++)
		{
			var dictionary = new Dictionary<char, char>();
			for (var j = 0; j < 9; j++)
			{
				if (board[j][i] == '.') continue;
				if (dictionary.ContainsKey(board[j][i])) return false;

				dictionary.Add(board[j][i], board[j][i]);
			}
		}

		for (var i = 0; i < 9; i += 3)
		{
			for (var j = 0; j < 9; j += 3)
			{
				var dictionary = new Dictionary<char, char>();
				var subboxes = new[]
				{
					board[i][j],
					board[i][j + 1],
					board[i][j + 2],
					board[i + 1][j],
					board[i + 1][j + 1],
					board[i + 1][j + 2],
					board[i + 2][j],
					board[i + 2][j + 1],
					board[i + 2][j + 2]
				};

				for (var temp = 0; temp < 9; temp++)
				{
					if (subboxes[temp] == '.') continue;
					if (dictionary.ContainsKey(subboxes[temp])) return false;
					dictionary.Add(subboxes[temp], subboxes[temp]);
				}
			}
		}

		return true;
	}


	public static char[][] GetTestData()
	{
		var testData = new[]
		{
			new[] { '.', '.', '.', '.', '5', '.', '.', '1', '.' },
			new[] { '.', '4', '.', '3', '.', '.', '.', '.', '.' },
			new[] { '.', '.', '.', '.', '.', '3', '.', '.', '1' },
			new[] { '8', '.', '.', '.', '.', '.', '.', '2', '.' },
			new[] { '.', '.', '2', '.', '7', '.', '.', '.', '.' },
			new[] { '.', '1', '5', '.', '.', '.', '.', '.', '.' },
			new[] { '.', '.', '.', '.', '.', '2', '.', '.', '.' },
			new[] { '.', '2', '.', '9', '.', '.', '.', '.', '.' },
			new[] { '.', '.', '4', '.', '.', '.', '.', '.', '.' }
		};

		return testData;
	}


	[Fact]
	public void Test()
	{
		var board = GetTestData();
		var check = IsValidSudokuSolution(board);
		Assert.False(check);
	}
}