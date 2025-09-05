using System.Diagnostics;

public enum State
{
    Win,
    Draw,
    Ongoing,
    Invalid
}

public class TicTacToe
{
    private string[] board;
    public TicTacToe(string[] rows)
    {
        board = rows;
        // check for validity of board
        checkForTurnOrder();
        var won = checkforWins();
        var full = checkIfFull();
        if (!(this.state == State.Invalid))
        {
            if (won)
            {
                this.State = State.Win;
            }
            else if (full)
            {
                this.State = State.Draw;
            }
            else
            {
                this.State = State.Ongoing;
            }
        }
    }

    private State state;
    public State State
    {
        get
        {
            return this.state;
        }
        private set
        {
            this.state = value;
        }
    }

    private bool checkIfFull()
    {
        var result = true;

        foreach (string row in board)
        {
            foreach (char letter in row)
            {
                if (letter == ' ') result = false;
            }
        }
        return result;
    }
    private void checkForTurnOrder()
    {
        var xAmount = 0;
        var oAmount = 0;

        foreach (string row in board)
        {
            foreach (char letter in row)
            {
                switch (letter)
                {
                    case 'X':
                        xAmount++;
                        break;
                    case 'O':
                        oAmount++;
                        break;
                }
            }
        }
        Trace.WriteLine(xAmount);
        Trace.WriteLine(oAmount);
        Trace.WriteLine("----------");
        if (!(xAmount == oAmount || oAmount + 1 == xAmount))
        {
            this.State = State.Invalid;
        }

    }
    private bool checkforWins()
    {
        var xWins = 0;
        var oWins = 0;
        for (int x = 0; x < 3; x++)
        {
            // check rows
            if (board[x][0] != ' ' && (board[x][0] == board[x][1] && board[x][1] == board[x][2]))
            {
                if (board[x][0] == 'X') xWins++; else oWins++;
            }
            // check for columns
            if (board[0][x] != ' ' && (board[0][x] == board[1][x] && board[1][x] == board[2][x]))
            {
                if (board[0][x] == 'X') xWins++; else oWins++;
            }
        }
        // check diagonals
        if (board[0][0] != ' ' && (board[0][0] == board[1][1] && board[1][1] == board[2][2]))
        {
            if (board[0][0] == 'X') xWins++; else oWins++;
        }
        if (board[2][0] != ' ' && (board[2][0] == board[1][1] && board[1][1] == board[0][2]))
        {
            if (board[2][0] == 'X') xWins++; else oWins++;
        }
        // if there is a win for X and for O the board is invalid
        if (xWins != 0 && oWins != 0)
        {
            this.State = State.Invalid;
        }
        if (xWins != 0 || oWins != 0) {
            return true;
        } else
        {
            return false;
        }
    }
}
