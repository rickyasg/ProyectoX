﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HamDataTransactions
{
    public class DBSecurity
    {
        public static string Encriptar(string textoQueEncriptaremos)
        {
            return Encriptar(textoQueEncriptaremos, "r1c@rd0m3nd0z@", "v3r1t0", "MD5", 1, "@m0rv3rd@d3r8123", 128);
        }

        public static string Encriptar(string textoQueEncriptaremos, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoQueEncriptaremos);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        public static string Desencriptar(string textoEncriptado)
        {
            return Desencriptar(textoEncriptado, "r1c@rd0m3nd0z@", "v3r1t0", "MD5", 1, "@m0rv3rd@d3r8123", 128);
        }

        public static string Desencriptar(string textoEncriptado, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };

            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;
        }
    }
}
