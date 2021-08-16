using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System;
using System.Security.Cryptography;

public class Md5 : MonoBehaviour
{
    public static string Md5Sum(string str)
    {
        byte[] data = Encoding.GetEncoding("utf-8").GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] OutBytes = md5.ComputeHash(data);

        string OutString = "";
        for (int i = 0; i < OutBytes.Length; i++)
        {
            OutString += OutBytes[i].ToString("x2");
        }
        // return OutString.ToUpper();
        return OutString.ToLower();
    }
   


}
