using System.Runtime.CompilerServices;

class WeighingMachine
{
    public int Precision { get; }

    private double weight;
    public double Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                this.weight = value;
            }
        }
    }
    public double TareAdjustment { get; set; } = 5;
    
    public string DisplayWeight
    {
        get
        {
            return (this.weight - this.TareAdjustment).ToString($"F{this.Precision}") + " kg";
        }
    }

    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }
}
