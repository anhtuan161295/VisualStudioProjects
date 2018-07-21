using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Lab06.Models
{
    public class PasscodeSecurity
    {
        static byte[] Key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        static byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        public static string encPasscode(string inputPasscode)
        {
            byte[] arrInput = Encoding.UTF8.GetBytes(inputPasscode);
            RijndaelManaged rm = new RijndaelManaged();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rm.CreateEncryptor(Key, IV), CryptoStreamMode.Write);
            cs.Write(arrInput, 0, arrInput.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string decPasscode(string outputPasscode)
        {
            byte[] arrInput = Convert.FromBase64String(outputPasscode);
            RijndaelManaged rm = new RijndaelManaged();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rm.CreateDecryptor(Key, IV), CryptoStreamMode.Write);
            cs.Write(arrInput, 0, arrInput.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}