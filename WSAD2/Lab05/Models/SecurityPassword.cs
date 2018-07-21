using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace Lab05.Models
{
    class SecurityPassword
    {
        public static string EncryptDecryptPassword(string pass)
        {
            HashAlgorithmProvider hash = HashAlgorithmProvider.OpenAlgorithm("SHA512");
            IBuffer ibuffer = CryptographicBuffer.DecodeFromBase64String(pass);
            return CryptographicBuffer.EncodeToHexString(hash.HashData(ibuffer));
        }
    }
}