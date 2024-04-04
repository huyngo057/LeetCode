namespace LeetCode;

public class ValidParentheses
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var item in s)
        {
            if (IsOpeningBracket(item))
            {
                stack.Push(item);
            }
            else if (IsClosingBracket(item))
            {
                if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), item))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    static bool IsOpeningBracket(char c)
    {
        return c is '(' or '{' or '[';
    }

    static bool IsClosingBracket(char c)
    {
        return c is ')' or '}' or ']';
    }

    static bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }
    
    [Theory]
    [InlineData("()")]
    [InlineData("()[]{}")]
    public void Test(string testData)
    {
        Assert.Equal(true, IsValid(testData));
    }
}