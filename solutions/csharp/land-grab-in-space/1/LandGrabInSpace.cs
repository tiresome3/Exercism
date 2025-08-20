using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override readonly bool Equals(object obj)
    {
        if (obj is Coord other)
        {
            return other.X == this.X && other.Y == this.Y;
        } else
        {
            return false;
        }
    }
}

public struct Plot
{
    public Coord coordA { get; }
    public Coord coordB { get; }
    public Coord coordC { get; }
    public Coord coordD { get; }

    public Plot(Coord coordA, Coord coordB, Coord coordC, Coord coordD)
    {
        this.coordA = coordA;
        this.coordB = coordB;
        this.coordC = coordC;
        this.coordD = coordD;
    }

    public override bool Equals(object obj)
    {
        if (obj is Plot other)
        {
            return other.coordA.Equals(this.coordA) && other.coordB.Equals(this.coordB) && 
                other.coordC.Equals(this.coordC) && other.coordD.Equals(this.coordD);
        } else
        {
            return false;
        }
    }
}


public class ClaimsHandler
{
    private static List<Plot> stakedClaims = new List<Plot>();
    public void StakeClaim(Plot plot)
    {
        stakedClaims.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return stakedClaims.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return plot.Equals(stakedClaims[stakedClaims.Count - 1]);
    }

    public Plot GetClaimWithLongestSide()
    {
        List<double> longestSides = new List<double>();
        foreach (Plot claim in stakedClaims)
        {
            List<double> distances = new List<double>();
            distances.Add(calculateDistance(claim.coordA, claim.coordB));
            distances.Add(calculateDistance(claim.coordB, claim.coordC));
            distances.Add(calculateDistance(claim.coordC, claim.coordD));
            distances.Add(calculateDistance(claim.coordD, claim.coordA));
 
            longestSides.Add(distances.Max());
        }
        return stakedClaims[longestSides.IndexOf(longestSides.Max())];
    }

    private double calculateDistance(Coord coordA, Coord coordB)
    {
        return Math.Sqrt(Math.Pow(coordB.X - coordA.X, 2) + Math.Pow(coordB.Y - coordA.Y, 2));
    }
}
