using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace Lab03.Models
{
    public static class CryptographyLibrary
    {
        static string pw = "123456";
        static string salt = "abcdef";

        public static string Encrypt(string plainText)
        {
            //Chuyen password sang IBuffer theo dinh dang Utf8
            IBuffer pwBuffer = CryptographicBuffer.ConvertStringToBinary(pw, BinaryStringEncoding.Utf8);
            //Chuyen salt theo dinh dang Utf8
            IBuffer saltBuffer = CryptographicBuffer.ConvertStringToBinary(salt, BinaryStringEncoding.Utf8);
            //Chuyen chuoi can ma hoa sang IBuffer theo dinh dang Utf8
            IBuffer plainBuffer = CryptographicBuffer.ConvertStringToBinary(plainText, BinaryStringEncoding.Utf8);
            //Khai bao thuat toan bam
            KeyDerivationAlgorithmProvider keyDerivationProvider = KeyDerivationAlgorithmProvider.OpenAlgorithm("PBKDF2_SHA1");
            //Tao param key gia tri salt voi so lan lap 1000 theo thuat toan PBKDF2_SHA1
            KeyDerivationParameters pbkdf2Parms = KeyDerivationParameters.BuildForPbkdf2(saltBuffer, 1000);
            //Tao KeyOriginal de ma hoa tu mat khau
            CryptographicKey keyOriginal = keyDerivationProvider.CreateKey(pwBuffer);
            //Tao KeyMaterial de ma hoa tu keyOriginal va key cua Salt voi kich thuoc 32 byte
            IBuffer keyMaterial = CryptographicEngine.DeriveKeyMaterial(keyOriginal, pbkdf2Parms, 32);
            //Tao saltMaterial de ma hoa tu derivedPwKey va key cua Salt voi kich thuoc la 16 byte
            IBuffer saltMaterial = CryptographicEngine.DeriveKeyMaterial(keyOriginal, pbkdf2Parms, 16);
            //Khai bao thuat toan ma hoa
            SymmetricKeyAlgorithmProvider symProvider = SymmetricKeyAlgorithmProvider.OpenAlgorithm("AES_CBC_PKCS7");

            //Tao key ma hoa tu keyMaterial
            CryptographicKey symmKey = symProvider.CreateSymmetricKey(keyMaterial);
            //Ma hoa chuoi du lieu
            IBuffer resultBuffer = CryptographicEngine.Encrypt(symmKey, plainBuffer, saltMaterial);
            //Chuyen du lieu sau khi ma hoa sang dang chuoi
            return CryptographicBuffer.EncodeToBase64String(resultBuffer);
        }

        public static string Decrypt(string encryptedData)
        {
            //Chuyen password sang IBuffer theo dinh dang Utf8
            IBuffer pwBuffer = CryptographicBuffer.ConvertStringToBinary(pw, BinaryStringEncoding.Utf8);
            //Chuyen salt theo dinh dang Utf8
            IBuffer saltBuffer = CryptographicBuffer.ConvertStringToBinary(salt, BinaryStringEncoding.Utf8);
            //Chuyen du lieu chuoi sang IBuffer de giai ma
            IBuffer cipherBuffer = CryptographicBuffer.DecodeFromBase64String(encryptedData);
            KeyDerivationAlgorithmProvider keyDerivationProvider = KeyDerivationAlgorithmProvider.OpenAlgorithm("PBKDF2_SHA1");
            KeyDerivationParameters pbkdf2Parms = KeyDerivationParameters.BuildForPbkdf2(saltBuffer, 1000);
            CryptographicKey keyOriginal = keyDerivationProvider.CreateKey(pwBuffer);
            IBuffer keyMaterial = CryptographicEngine.DeriveKeyMaterial(keyOriginal, pbkdf2Parms, 32);
            IBuffer saltMaterial = CryptographicEngine.DeriveKeyMaterial(keyOriginal, pbkdf2Parms, 16);
            SymmetricKeyAlgorithmProvider symProvider = SymmetricKeyAlgorithmProvider.OpenAlgorithm("AES_CBC_PKCS7");
            CryptographicKey symmKey = symProvider.CreateSymmetricKey(keyMaterial);
            //Giai ma
            IBuffer resultBuffer = CryptographicEngine.Decrypt(symmKey, cipherBuffer, saltMaterial);
            //Chuyen tu dinh dang IBuffer ve chuoi ban dau
            string result = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, resultBuffer);
            return result;
        }
    }
}