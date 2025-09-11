public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        var faceCounter = new int[6] {0, 0, 0, 0, 0, 0 };
        var total = 0;
        foreach (int roll in dice)
        {
            faceCounter[roll - 1]++;
            total += roll;
        }
        switch (category)
        {
            case YachtCategory.LittleStraight:
                if (dice.Contains(1) && dice.Contains(2) && dice.Contains(3) &&
                    dice.Contains(4) && dice.Contains(5)) return 30; else return 0;
            case YachtCategory.BigStraight:
                if (dice.Contains(6) && dice.Contains(2) && dice.Contains(3) &&
                    dice.Contains(4) && dice.Contains(5)) return 30; else return 0;
            case YachtCategory.Yacht:
                if (faceCounter.Max() == 5) return 50; else return 0;
            case YachtCategory.Choice:
                return total;
            case YachtCategory.FourOfAKind:
                return FourOfAKind(dice, faceCounter, total);
            case YachtCategory.FullHouse:
                return FullHouse(dice, faceCounter, total);
            case YachtCategory.Ones:
            case YachtCategory.Twos:
            case YachtCategory.Threes:
            case YachtCategory.Fours:
            case YachtCategory.Fives:
            case YachtCategory.Sixes:
                return MultiplesOfNumber(dice, (int)category);
            default:
                throw new ArgumentException();
            }

    }
    private static int FourOfAKind(int[] dice, int[] faceCounter, int total)
    {
        if (faceCounter.Max() >= 4)
        {
            int ind = 0;
            for (int x = 0; x < faceCounter.Length; x++)
            {
                if (faceCounter[x] == faceCounter.Max())
                {
                    ind = x;
                }
            }
            return (ind + 1) * 4;
        } else
        {
            return 0;
        }

    }
    private static int FullHouse(int[] dice, int[] faceCounter, int total)
    {
        if (faceCounter.Contains(3) && faceCounter.Contains(2))
        {
            return total;
        } else
        {
            return 0;
        }
    }
    private static int MultiplesOfNumber(int[] dice, int number)
    {
        var numberOfOccurences = 0;
        var result = 0;
        foreach (int roll in dice)
        {
            if (roll == number)
            {
                numberOfOccurences++;
            }
        }
        result = number * numberOfOccurences;
        return result;
    }
}

