using System.Runtime.CompilerServices;

public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    private DndCharacter()
    {
        this.Strength = Ability();
        this.Dexterity = Ability();
        this.Constitution = Ability();
        this.Intelligence = Ability();
        this.Wisdom = Ability();
        this.Charisma = Ability();
        this.Hitpoints = 10 + Modifier(this.Constitution);
    }
    public static int Modifier(int score)
    {
        
        return (int)Math.Floor(((double)score - 10.0) / 2.0);
    }

    public static int Ability() 
    {
        var diceRolls = new int[4];
        var rand = new Random();
        for (int x = 0; x < 4; x++)
        {
            diceRolls[x] = rand.Next(6) + 1;
        }
        Array.Sort(diceRolls);
        return diceRolls[1] + diceRolls[2] + diceRolls[3];
    }

    public static DndCharacter Generate()
    {
        return new DndCharacter();
    }
}
