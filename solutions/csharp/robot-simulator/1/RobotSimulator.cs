using Xunit.Sdk;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        this.direction = direction;
        this.x = x;
        this.y = y;
    }

    private Direction direction;
    private int x;
    private int y;
    public Direction Direction
    {
        get
        {
            return this.direction;
        }
    }

    public int X
    {
        get
        {
            return this.x;
        }
    }

    public int Y
    {
        get
        {
            return this.y;
        }
    }

    public void Move(string instructions)
    {
        foreach (char instruction in instructions)
        {
            switch (instruction)
            {
                case 'A':
                    AdvanceRobot();
                    break;
                case 'L':
                    turnRobotLeft();
                    break;
                case 'R':
                    turnRobotRight();
                    break;
            }
        }
    }
    private void AdvanceRobot()
    {
        switch (this.Direction)
        {
            case Direction.North:
                this.y++;
                break;
            case Direction.South:
                this.y--;
                break;
            case Direction.East:
                this.x++;
                break;
            case Direction.West:
                this.x--;
                break;
        }
    }
    private void turnRobotLeft()
    {
        switch (this.Direction)
        {
            case Direction.North:
                this.direction = Direction.West;
                break;
            case Direction.South:
                this.direction = Direction.East;
                break;
            case Direction.East:
                this.direction = Direction.North;
                break;
            case Direction.West:
                this.direction = Direction.South;
                break;
        }
    }
    private void turnRobotRight()
    {
        switch (this.Direction)
        {
            case Direction.North:
                this.direction = Direction.East;
                break;
            case Direction.South:
                this.direction = Direction.West;
                break;
            case Direction.East:
                this.direction = Direction.South;
                break;
            case Direction.West:
                this.direction = Direction.North;
                break;
        }

    }
}