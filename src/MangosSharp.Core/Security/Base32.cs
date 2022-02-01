/*
 * Derived from https://github.com/google/google-authenticator-android/blob/master/AuthenticatorApp/src/main/java/com/google/android/apps/authenticator/Base32String.java
 * 
 * Copyright (C) 2016 BravoTango86
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Text;

namespace MangosSharp.Core.Security;

public static class Base32
{
    private static readonly char[] Digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".ToCharArray();
    private const int Mask = 31;
    private const int Shift = 5;

    private static int CharToInt(char c)
    {
        return c switch
        {
            'A' => 0,
            'B' => 1,
            'C' => 2,
            'D' => 3,
            'E' => 4,
            'F' => 5,
            'G' => 6,
            'H' => 7,
            'I' => 8,
            'J' => 9,
            'K' => 10,
            'L' => 11,
            'M' => 12,
            'N' => 13,
            'O' => 14,
            'P' => 15,
            'Q' => 16,
            'R' => 17,
            'S' => 18,
            'T' => 19,
            'U' => 20,
            'V' => 21,
            'W' => 22,
            'X' => 23,
            'Y' => 24,
            'Z' => 25,
            '2' => 26,
            '3' => 27,
            '4' => 28,
            '5' => 29,
            '6' => 30,
            '7' => 31,
            _ => -1
        };
    }

    public static Span<byte> FromBase32String(string encoded)
    {
        if (encoded == null)
            throw new ArgumentNullException(nameof(encoded));

        // Remove whitespace and padding. Note: the padding is used as hint 
        // to determine how many bits to decode from the last incomplete chunk
        // Also, canonicalize to all upper case
        encoded = encoded.Trim().TrimEnd('=').ToUpper();
        if (encoded.Length == 0)
            return Array.Empty<byte>();

        var outLength = encoded.Length * Shift / 8;
        var result = new byte[outLength];
        var buffer = 0;
        var next = 0;
        var bitsLeft = 0;
        foreach (var c in encoded)
        {
            var charValue = CharToInt(c);
            if (charValue < 0)
                throw new FormatException($"Illegal character: `{c}`");

            buffer <<= Shift;
            buffer |= charValue & Mask;
            bitsLeft += Shift;
            if (bitsLeft < 8) 
                continue;
            result[next++] = (byte)(buffer >> (bitsLeft - 8));
            bitsLeft -= 8;
        }

        return result;
    }

    public static string ToBase32String(ReadOnlySpan<byte> data, bool padOutput = false)
    {
        return ToBase32String(data, 0, data.Length, padOutput);
    }

    public static string ToBase32String(ReadOnlySpan<byte> data, int offset, int length, bool padOutput = false)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        if (offset < 0)
            throw new ArgumentOutOfRangeException(nameof(offset));

        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length));

        if ((offset + length) > data.Length)
            throw new ArgumentOutOfRangeException();

        switch (length)
        {
            case 0:
                return string.Empty;
            // SHIFT is the number of bits per output character, so the length of the
            // output is the length of the input multiplied by 8/SHIFT, rounded up.
            // The computation below will fail, so don't do it.
            case >= 1 << 28:
                throw new ArgumentOutOfRangeException(nameof(data));
        }

        var outputLength = (length * 8 + Shift - 1) / Shift;
        var result = new StringBuilder(outputLength);

        var last = offset + length;
        int buffer = data[offset++];
        var bitsLeft = 8;
        while (bitsLeft > 0 || offset < last)
        {
            if (bitsLeft < Shift)
            {
                if (offset < last)
                {
                    buffer <<= 8;
                    buffer |= (data[offset++] & 0xff);
                    bitsLeft += 8;
                }
                else
                {
                    var pad = Shift - bitsLeft;
                    buffer <<= pad;
                    bitsLeft += pad;
                }
            }

            var index = Mask & (buffer >> (bitsLeft - Shift));
            bitsLeft -= Shift;
            result.Append(Digits[index]);
        }

        if (!padOutput) 
            return result.ToString();

        var padding = 8 - result.Length % 8;
        if (padding > 0) 
            result.Append('=', padding == 8 ? 0 : padding);
        return result.ToString();
    }
}