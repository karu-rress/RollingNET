﻿using System;
using System.Security.Cryptography;
using ssc = System.Security.Cryptography;
using System.Text;

namespace RollingRess.Security;

public static class Encryptor
{
    public static string SHA256(string input)
    {
        using SHA256 sha256 = ssc::SHA256.Create();
        byte[] encryptBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(encryptBytes);
    }

    public static string SHA512(string input)
    {
        using SHA512 sha = ssc::SHA512.Create();
        byte[] encryptBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(encryptBytes);
    }
}
