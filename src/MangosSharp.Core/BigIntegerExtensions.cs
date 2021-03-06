using System;
using System.Numerics;

namespace MangosSharp.Core;

public static class BigIntegerExtensions
{
    public static BigInteger ModPow(this BigInteger value, BigInteger exponent, BigInteger modulus) =>
        BigInteger.ModPow(value, exponent, modulus);

    public static byte[] ToByteArray(this BigInteger value, int size, bool isUnsigned = false,
        bool isBigEndian = false)
    {
        var output = value.ToByteArray(isUnsigned, isBigEndian);
        Array.Resize(ref output, size);
        return output;
    }
}