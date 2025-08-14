using System.Diagnostics;
using System.Text;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        Trace.WriteLine(reading);
        var result = new byte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0};
        var byteArray = new byte[8];
        if (reading >= 4294967296)
        {
            result[0] = 256 - 8;
            byteArray = BitConverter.GetBytes((long)reading);
        } else if (reading >= 2147483648)
        {
            result[0] = 4;
            byteArray = BitConverter.GetBytes((uint)reading);
        } else if (reading >= 65536)
        {
            result[0] = 256 - 4;
            byteArray = BitConverter.GetBytes((int)reading);
        } else if (reading >= 0)
        {
            result[0] = 2;
            byteArray = BitConverter.GetBytes((ushort)reading);
        } else if (reading >= -32768)
        {
            result[0] = 256 - 2;
            byteArray = BitConverter.GetBytes((short)reading);
        } else if (reading >= -2147483648)
        {
            result[0] = 256 - 4;
            byteArray = BitConverter.GetBytes((int)reading);
        } else if (reading >= -9223372036854775808)
        {
            result[0] = 256 - 8;
            byteArray = BitConverter.GetBytes((long)reading);
        }
        
        for (int x = 0; x < byteArray.Length; x++)
        {
            result[x + 1] = byteArray[x];
        }

        return result;
    }

    public static long FromBuffer(byte[] buffer)
    {
        switch (buffer[0])
        {
            case 248:
                return BitConverter.ToInt64(buffer, 1);
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case 252:
                return BitConverter.ToInt32(buffer, 1);
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            case 254:
                return BitConverter.ToInt16(buffer, 1);
            default:
                return 0;
        }
    }
}
