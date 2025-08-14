using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

using Xunit.Internal;

public static class MatchingBrackets
{
    static char[] openBrackets =  { '(', '[', '{' };
    static char[] closeBrackets =  { ')', ']', '}' };
    public static bool IsPaired(string input)
    {
        var stack = new List<Char> {};
        for (int x = 0; x < input.Length; x++)
        {
            if (openBrackets.Contains(input[x]))
            {
                stack.Add(input[x]);
            } else if (closeBrackets.Contains(input[x]))
            {
                if (stack.Count == 0)
                {
                    return false;
                } else if (input[x] == ')' && stack[stack.Count -1] == '(')
                {
                    stack.RemoveAt(stack.Count - 1);
                } else if (input[x] == ']' && stack[stack.Count -1] == '[')
                {
                    stack.RemoveAt(stack.Count - 1);
                } else if (input[x] == '}' && stack[stack.Count -1] == '{')
                {
                    stack.RemoveAt(stack.Count - 1);
                } else
                {
                    return false;
                }
            }
        }
        if (stack.Count == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
