using System.Diagnostics;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    public override bool Equals(object? obj)
    {
        if (obj is FacialFeatures other)
        {
            return this.EyeColor == other.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;
        } else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return (EyeColor.GetHashCode() * 17) ^ (PhiltrumWidth.GetHashCode() * 23);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    public override bool Equals(object? obj)
    {
        if (obj is Identity other)
        {
            return this.Email == other.Email && this.FacialFeatures.Equals(other.FacialFeatures);
        } else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
        return (Email.GetHashCode() * 17) ^ (FacialFeatures.GetHashCode() * 23);
    }
}

public class Authenticator
{
    private static Identity adminIdentity = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9M));
    private Identity registeredIdentity = null;
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(adminIdentity);
    }

    public bool Register(Identity identity)
    {
        if (registeredIdentity == null || !identity.Equals(registeredIdentity))
        {
            registeredIdentity = identity;
            return true;
        } else
        {
            return false;
        }
    }

    public bool IsRegistered(Identity identity)
    {
        return identity.Equals(registeredIdentity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA == identityB;
    }
}
