public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        var canAttack = false;
        var rowDifference = Math.Abs(white.Row - black.Row);
        var columnDifference = Math.Abs(white.Column - black.Column);
        if (white.Row == black.Row || white.Column == black.Column || rowDifference == columnDifference)
        {
           canAttack = true;
        }
        return canAttack;
    }

    public static Queen Create(int row, int column)
    {
        if (!(row >= 0 && row <= 7 && column >= 0 && column <= 7))
        {
            throw new ArgumentOutOfRangeException();
        }
        return new Queen(row, column);
    }
}