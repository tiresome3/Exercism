abstract class Character
{
    private string characterType;
    protected bool vulnerable;
    protected Character(string characterType)
    {
        this.characterType = characterType;
        this.vulnerable = false;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return this.vulnerable;
    }

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        } else
        {
            return 6;
        }
    }
}

class Wizard : Character
{
    private bool spellPrepared = false;
    public Wizard() : base("Wizard")
    {
        this.vulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
        if (spellPrepared)
        {
            return 12;
        } else
        {
            return 3;
        }
    }

    public void PrepareSpell()
    {
        this.spellPrepared = true;
        this.vulnerable = false;
    }
}
