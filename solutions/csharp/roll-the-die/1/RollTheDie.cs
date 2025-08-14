public class Player
{
    Random rnd = new Random();
    public int RollDie()
    {
        return rnd.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        double result = 0.0;
        while (result == 0.0)
        {
            result = rnd.NextDouble() * 100;
        }
        return result;
    }
}
