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
    // TODO: implement equality and GetHashCode() methods
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
    // TODO: implement equality and GetHashCode() methods
}

public class Authenticator
{
    private Identity registeredIdentity = null;
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.EyeColor == faceB.EyeColor && faceA.PhiltrumWidth == faceB.PhiltrumWidth;
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Email == "admin@exerc.ism" && identity.FacialFeatures.EyeColor == "green" && identity.FacialFeatures.PhiltrumWidth == 0.9M;
    }

    public bool Register(Identity identity)
    {
        Trace.WriteLine(registeredIdentity == null);
        if (registeredIdentity == null || !(AreSameFace(registeredIdentity.FacialFeatures, identity.FacialFeatures) && registeredIdentity.Email == identity.Email))
        {
            registeredIdentity = identity;
            Trace.WriteLine("hi");
            return true;
        } else
        {
            return false;
        }

    }

    public bool IsRegistered(Identity identity)
    {
        return AreSameFace(registeredIdentity.FacialFeatures, identity.FacialFeatures) && registeredIdentity.Email == identity.Email;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA.Equals(identityB);
    }
}
