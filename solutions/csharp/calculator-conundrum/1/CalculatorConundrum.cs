public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation != null)
        {
            if (operand2== 0)
            {
                return "Division by zero is not allowed.";
            }
            else if (operation == "+")
            {
                return $"{operand1} {operation} {operand2} = { operand1 + operand2}";
            } else if (operation == "*")
            {
                return $"{operand1} {operation} {operand2} = { operand1 * operand2}";
            } else if (operation == "/")
            {
                return $"{operand1} {operation} {operand2} = { operand1 / operand2}";
            } else if (operation == "")
            {
                throw new ArgumentException();
            } else
            {
                throw new ArgumentOutOfRangeException();
            }

        } else
        {
            throw new ArgumentNullException();
        }
    }
}
